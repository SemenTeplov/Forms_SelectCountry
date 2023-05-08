namespace LessonFormsCSharp
{
    internal class City
    {
        public City() 
        {
            nameCity_ = new string("");
            population_ = new string("");
        }
        public City(string nameCity) 
        {
            nameCity_ = new string(nameCity);
            population_ = new string("");
        }
        public City(string nameCity, string population) 
        {
            nameCity_ = new string(nameCity);
            population_ = new string(population);
        }

        public string GetNameCity() 
        {
            return nameCity_;
        }
        public string GetPopulation() 
        { 
            return population_; 
        }

        private string nameCity_;
        private string population_;
    }
}
