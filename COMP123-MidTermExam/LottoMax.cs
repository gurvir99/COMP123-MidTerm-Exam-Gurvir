using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP123_MidTermExam
{
    //STUDENT NAME: Gurvir Singh
    //STUDENT ID: #301108852
    //COURSE NAME: Programming 2
    //COURSE CODE: SEC.001
    //Midterm Test
    /**
    * <summary>
    * This class is a subclass of the LottoGame abstract superclass
    * </summary>
    * 
    * @class LottoMax
    */
    public class LottoMax : LottoGame, IGenerateLottoNumbers
    {
        /**
         * <summary>
         * This constructor does not take any parameters but satisfies the
         * base constructor requirements by send the elementNumber and setSize
         * </summary>
         * 
         * @constructor
         */
        public LottoMax()
            :base(7,49)
        {
            
        }

        // CREATE the public GenerateLottoNumbers method here ----------------
        public void GenerateLottoNumbers()
        {
            for (int i = 1; i <= 7; i++)
            {
                this.PickElements();
                Console.WriteLine($"TICKET {i}:  " + this.ToString());

            }
        }
    }
}