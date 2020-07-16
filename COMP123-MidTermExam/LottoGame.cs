using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_MidTermExam
{
    //STUDENT NAME: Gurvir Singh
    //STUDENT ID: #301108852
    //COURSE NAME: Programming 2
    //COURSE CODE: SEC.001
    //MIDTERM TEST
    /**
     * <summary>
     * This abstract class is a blueprint for all Lotto Games
     * </summary>
     * 
     * @class LottoGame
     * @property {int} ElementNum;
     * @property {int} SetSize;
     */
    public abstract class LottoGame
    {
        // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE private fields here --------------------------------------------
        private List<int> _elementList = new List<int>();
        private int _elementNumber;
        private List<int> _numberList = new List<int>();
        private Random _random = new Random();
        private int _setSize;


        // PUBLIC PROPERTIES ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE public properties here -----------------------------------------
        public List<int> ElementList
        {
            get { return _elementList; }
        }
        public int ElementNumber
        {
            get { return _elementNumber; }
            set { _elementNumber = value; }
        }
        public List<int> NumberList
        {
            get { return _numberList; }
        }
        public Random Random
        {
            get { return _random; }
        }
        public int SetSize
        {
            get { return _setSize; }
            set { _setSize = value; }
        }



        // CONSTRUCTORS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: elementNumber and setSize
         * The elementNumber parameter has a default value of 6
         * The setSize parameter has a default value of 49
         * </summary>
         * 
         * @constructor LottoGame
         * @param {int} elementNumber
         * @param {int} setSize
         */
        public LottoGame(int elementNumber = 6, int setSize = 49)
        {
            // assign elementNumber local variable to the ElementNumber property
            this.ElementNumber = elementNumber;

            // assign setSize local variable tot he SetSize property
            this.SetSize = setSize;

            // call the _initialize method
            this._initialize();

            // call the _build method
            this._build();
        }

        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the private _initialize method here -----------------------------
        private void _initialize()
        {
            _elementList = new List<int>();
            _numberList = new List<int>();
            _random = new Random();
        }

        // CREATE the private _build method here -----------------------------------
        private void _build()
        {
            for (int i = 1; i <= SetSize; i++)
            {
                NumberList.Add(i);
            }
        }

        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * Override the default ToString function so that it displays the current
         * ElementList
         * </summary>
         * 
         * @override
         * @method ToString
         * @returns {string}
         */
        public override string ToString()
        {
            // create a string variable named lottoNumberString and intialize it with the empty string
            string lottoNumberString = String.Empty;

            // for each lottoNumber in ElementList, loop...
            foreach (int lottoNumber in ElementList)
            {
                // add lottoNumber and appropriate spaces to the lottoNumberString variable
                lottoNumberString += lottoNumber > 9 ? (lottoNumber + " ") : (lottoNumber + "  ");
            }

            return lottoNumberString;
        }

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the public PickElements method here ----------------------------
        public void PickElements()
        {
            if (ElementList.Count > 0)
            {
                //ElementList and NumberList call their clear method:
                ElementList.Clear();
                NumberList.Clear();

                //build method is called:
                this._build();

                //6 random numbers are selected from NumberList, they are added to the ElementList and then removed from NumberList:
                IEnumerable<int> threeRandom = NumberList.OrderBy(x => Random.Next()).Take(this.ElementNumber);
                foreach (int y in threeRandom)
                {
                    ElementList.Add(y);
                }
                ElementList.Sort();
                NumberList.RemoveAll(c => ElementList.ToList().Exists(n => n == c));

            }
            else
            {
                //build method is called:
                this._build();

                //6 random numbers are selected from NumberList, they are added to the ElementList and then removed from NumberList:
                IEnumerable<int> threeRandom = NumberList.OrderBy(x => Random.Next()).Take(ElementNumber);
                foreach (int y in threeRandom)
                {
                    ElementList.Add(y);
                }
                NumberList.RemoveAll(c => ElementList.ToList().Exists(n => n == c));

            }
        }

    }
}
