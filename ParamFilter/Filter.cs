using System;

namespace perpusapi.ParamFilter
{
    public class Filter 
    {
        public string Search {get; set;}
        public int Page {get; set;} = 1;
        public int NumOfRows {get; set;} = 10;
    }
}