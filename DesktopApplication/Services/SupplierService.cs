using System.ComponentModel.DataAnnotations;
using DesktopApplication.Dto;
using DesktopApplication.ExternalHandlers;

namespace DesktopApplication.Services;

public class SupplierService(DbHandler db)
{
    public IEnumerable<Supplier> GetSuppliers() => db.Suppliers;

    public Supplier? GetSupplier(int id) => 
        db.Suppliers.FirstOrDefault(x => x.SupplierId == id);

    public Supplier? GetSupplier(string name) => 
        db.Suppliers.FirstOrDefault(x => x.Name == name);

    public void AddSupplier(Supplier supplier)
    {
        Validator.ValidateObject(supplier, new(supplier), true);
        db.Suppliers.Add(supplier);
        db.SaveChanges();
    }

    public void UpdateSupplier(Supplier supplier)
    {
        Validator.ValidateObject(supplier, new(supplier), true);
        db.Suppliers.Update(supplier);
        db.SaveChanges();
    }

    public void RemoveSupplier(int id)
    {
        Supplier? supplier = db.Suppliers.FirstOrDefault(x => x.SupplierId == id);

        if (supplier is not null)
            db.Suppliers.Remove(supplier);
    }
}