namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class inherited from List class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomList<T> : List<T>
    {
        private int _size;

        /// <summary>
        /// Constructor assigns size of list
        /// </summary>
        /// <param name="s"></param>
        public CustomList(int s)
        {
            _size = s;
        }

        /// <summary>
        /// Hide parent class List Add method
        /// </summary>
        /// <param name="item">Value to Add</param>
        public new void Add(T item)
        {
            if(Count >= _size)
            {
                Console.WriteLine("Cannot add item: List has reached its maximum capacity");
                return;
            }

            if (Contains(item))
            {
                Console.WriteLine("Item already exists. Only unique items are allowed.");
                return;
            }

            base.Add(item);
            Console.WriteLine($"Item added: {item}");
        }

        /// <summary>
        /// Hide parent class List Remove method
        /// </summary>
        /// <param name="item">Value to Remove</param>
        /// <returns>True if value removed else false</returns>
        public new bool Remove(T item)
        {
            if (!Contains(item))
            {
                Console.WriteLine("Item not found in the list.");
                return false;
            }
            Console.WriteLine("Item removed successfully");
            return base.Remove(item);
        }
    }

    /// <summary>
    /// Class containing BaseLibraryFeatureDemo method
    /// </summary>
    internal class BaseLibraryFeature
    {
        /// <summary>
        /// Method shows base library features demo
        /// </summary>
        public static void BaseLibraryFeatureDemo()
        {
            CustomList<int> list = new CustomList<int>(5);
            
            while(true)
            {
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Remove");
                Console.Write("Enter operation number: ");
                int input = Convert.ToInt16(Console.ReadLine());

                switch(input)
                {
                    case 1:
                        Console.Write("\nEnter value to Add: ");
                        int a = Convert.ToInt16(Console.ReadLine());
                        list.Add(a); break;
                    case 2:
                        Console.Write("\nEnter value to Remove: ");
                        int b = Convert.ToInt16(Console.ReadLine());
                        list.Remove(b); break;
                    default:
                        Console.WriteLine("Enter valid operation number"); break;
                }
            }
        }
    }
}
