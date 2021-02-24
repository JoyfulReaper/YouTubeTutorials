using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsLibrary
{
    public class DemoCode
    {
        public int GrandparentMethod(int postion)
        {
            int output = 0;

            Console.WriteLine("\"Open\" Database Connection");

            try
            {
                output = ParentMethod(postion);
            }
            catch (Exception ex)
            {
                // Could log the exception here
                //throw; // Pass exception "up the chain" like not catching. Re-trhow after running the finally code!
                throw new ArgumentException("You passed in bad data", ex);
            }
            finally
            {
                // Run this code anyway before passing the exception up the chain
                Console.WriteLine("\"Close\" Database Connection");
            }

            return output;
        }

        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }

        public int GetNumber(int position)
        {
            int output = 0;

            //try
            //{
                int[] numbers = new int[] { 1, 4, 7, 2 };
                output = numbers[position];
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}

            return output;
        }
    }
}
