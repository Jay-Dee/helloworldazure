namespace helloazure.Models {
    public static class PersonGenerator {
        public static void InitData(PersonContext context){
           for(int personCounter = 1; personCounter < 101; personCounter++) {
               context.Persons.Add(new Person(){Id= personCounter.ToString(), Name = $"Person{personCounter}", Address=$"AddressForPerson{personCounter}"});
           } 

           context.SaveChanges();
        }
    }
    
}