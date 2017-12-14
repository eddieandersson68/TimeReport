namespace TimeReport
{
    public  class Emp
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Emp(int id, string fname, string lname)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
        }

        // används ej
        public string MakeString()
        {
            return Id +  FirstName + LastName;
        }
    }
}

