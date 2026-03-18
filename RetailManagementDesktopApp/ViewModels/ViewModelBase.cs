using RetailManagementDesktopApp.Attributes;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RetailManagementDesktopApp.ViewModels;
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, 
        [CallerMemberName] string propertyName = "")
    {
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public bool Validate(out string[] errors)
    {
        bool result = true;
        List<string> errorList = new();

        foreach (PropertyInfo property in GetType().GetProperties()) 
        {
            FieldAttribute? attribute = 
                property.GetCustomAttribute(typeof(FieldAttribute)) as FieldAttribute;

            if (attribute is null)
                continue;


            if (property.PropertyType != typeof(string))
                throw new InvalidOperationException("FieldAttribute can only be applied to string properties.");
        
            string value = property.GetValue(this) as string ?? string.Empty;

            if (!attribute.Check && string.IsNullOrWhiteSpace(value)) {
                errorList.Add(attribute.ErrorMessage);
                result = false;
            } else if (attribute.Check) {
                PropertyInfo checkProp = GetType().GetProperty(attribute.Reference ?? string.Empty)
                    ?? throw new InvalidOperationException
                    ($"Reference property '{attribute.Reference}' not found.");

                if (checkProp.PropertyType != typeof(bool))
                    throw new InvalidOperationException("Reference property must be of type bool.");

                if ((bool)(checkProp.GetValue(this))! == true) {
                    if (string.IsNullOrWhiteSpace(value)) {
                        errorList.Add(attribute.ErrorMessage);
                        result = false;
                    }
                }
            }
        }

        errors = [.. errorList];
        return result;
    }
}
