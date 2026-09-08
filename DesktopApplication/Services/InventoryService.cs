using System.ComponentModel.DataAnnotations;
using DesktopApplication.Dto;
using DesktopApplication.ExternalHandlers;

namespace DesktopApplication.Services;

public class InventoryService(DbHandler db)
{
    public enum FilterTypes
    {
        Brand, Supplier, Type, Name
    }
    
    public IEnumerable<Item> GetInventory() => db.Inventory;

    public IEnumerable<Item> GetInventory(FilterTypes[] filters, string[] items)
    {
        List<Item> result = db.Inventory.ToList();

        for (int i = 0; i < filters.Length; i++)
        {
            switch (filters[i])
            {
                case FilterTypes.Brand:
                    result = result.Where(x => x.Brand == items[i]).ToList();
                    break;
                case FilterTypes.Type:
                    result = result.Where(x => x.Type == items[i]).ToList();
                    break;
                case FilterTypes.Supplier:
                    result = result.Where(x => x.SupplierId == int.Parse(items[i])).ToList();
                    break;
                case FilterTypes.Name:
                    result = result.Where(x => x.Name == items[i]).ToList();
                    break;
            }
        }

        return result;
    }
    
    public Item? GetItem(int id) => db.Inventory.FirstOrDefault(x => x.ItemId == id);

    public void AddItem(Item item)
    {
        Validator.ValidateObject(item, new(item), true);
        db.Inventory.Add(item);
        db.SaveChanges();
    }
    
    public void AddItems(Item[] items)
    {
        foreach (Item item in items)
        {
            Validator.ValidateObject(item, new(item), true);
            db.Inventory.Add(item);
        }
        
        db.SaveChanges();
    }

    public void RemoveItem(int id)
    {
        Item? item = db.Inventory.FirstOrDefault(x => x.ItemId == id);
        
        if (item is not null)
            db.Inventory.Remove(item);
        
        db.SaveChanges();
    }
    
    public void RemoveItems(int[] items)
    {
        foreach (int id in items)
        {
            Item? item = db.Inventory.FirstOrDefault(x => x.ItemId == id);
        
            if (item is not null)
                db.Inventory.Remove(item);
        }
        
        db.SaveChanges();
    }
}