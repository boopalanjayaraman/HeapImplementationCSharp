using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Price data that represents open, close, high, low prices of a particular security on a day
    /// </summary>
    public class PriceData
    {
        public PriceData()
        {

        }

        /// <summary>
        /// Id of the security, if any.
        /// </summary>
        public int SecurityId { get; set; }

        /// <summary>
        /// Security Name
        /// </summary>
        public string SecurityName { get; set; }

        /// <summary>
        /// Date in context, which the prices reflect
        /// Integer format - yyyymmdd, makes things easier 
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Open price of the security
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// Close price of the security
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// High price of the security
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Low price of the security
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Other stats for the day, if any
        /// </summary>
        public Dictionary<string, double> DayStats { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Id : {0} | ", this.SecurityId);
            builder.AppendFormat("Name : {0} | ", this.SecurityName);
            builder.AppendFormat("Open : {0} | ", this.Open);
            builder.AppendFormat("Close : {0} | ", this.Close);
            builder.AppendFormat("High : {0} | ", this.High);
            builder.AppendFormat("Low : {0} | ", this.Low);
            return builder.ToString();
        }

    }
}
