using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Sinister.Domain.Model.Entities;

public class Customer
{
    public CustomerId Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public ESex Sex { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    
    public int Sinisters { get; private set; }

    public Customer()
    {
        
    }
    
    public Customer(CustomerId id, string firstName, string lastName, ESex sex, DateTime birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Sex = sex;
        BirthDate = birthDate;
        Sinisters = 0;
    }

    public void IncreaseSinisters()
    {
        Sinisters++;
    }
}