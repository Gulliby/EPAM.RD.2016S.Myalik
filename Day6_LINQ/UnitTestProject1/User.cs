namespace UnitTestProject1
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return string.Format("[Name: {0}; Age: {1}; Salary: {2}; Gander: {3};]", Name, Age, Salary, Gender);
        }

        public override bool Equals(object obj)
        {
            var userObj = obj as User;
            if (userObj == null)
                return false;

            return Name == userObj.Name && Age == userObj.Age && Salary == userObj.Salary && Gender ==userObj.Gender;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
