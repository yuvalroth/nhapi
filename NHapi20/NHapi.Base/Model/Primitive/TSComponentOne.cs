/// <summary> The contents of this file are subject to the Mozilla Public License Version 1.1
/// (the "License"); you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/
/// Software distributed under the License is distributed on an "AS IS" basis,
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
/// specific language governing rights and limitations under the License.
/// 
/// The Original Code is "TSComponentOne.java".  Description:
/// "Represents an HL7 timestamp, which is related to the HL7 TS type."
/// 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C)
/// 2005.  All Rights Reserved.
/// 
/// Contributor(s): ______________________________________.
/// 
/// Alternatively, the contents of this file may be used under the terms of the
/// GNU General Public License (the  �GPL�), in which case the provisions of the GPL are
/// applicable instead of those above.  If you wish to allow use of your version of this
/// file only under the terms of the GPL and not to allow others to use your version
/// of this file under the MPL, indicate your decision by deleting  the provisions above
/// and replace  them with the notice and other provisions required by the GPL License.
/// If you do not delete the provisions above, a recipient may use your version of
/// this file under either the MPL or the GPL.
/// </summary>

namespace NHapi.Base.Model.Primitive
{
    using System;

    /// <summary> Represents an HL7 timestamp, which is related to the HL7 TS type.  In version 2.5, 
    /// TS is a composite type.  The first component is type DTM, which corresponds to this class
    /// (actually Model.v25.datatype.DTM inherits from this class at time of writing).  In HL7 versions 
    /// 2.2-2.4, it wasn't perfectly clear whether TS was composite or primitive.  HAPI interprets  
    /// it as composite, with the first component having a type that isn't defined by HL7, and we call 
    /// this type TSComponentOne.  In v2.1, TS is primitive, and corresponds one-to-one with this class.   
    /// 
    /// </summary>
    /// <author>  <a href="mailto:neal.acharya@uhn.on.ca">Neal Acharya</a>
    /// </author>
    /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
    /// </author>
    /// <version>  $Revision: 1.4 $ updated on $Date: 2005/06/14 20:09:39 $ by $Author: bryan_tripp $
    /// </version>
    public class TSComponentOne : AbstractPrimitive
    {
        #region Fields

        private CommonTS myDetail;

        #endregion

        #region Constructors and Destructors

        /// <param name="theMessage">message to which this Type belongs
        /// </param>
        public TSComponentOne(IMessage theMessage)
            : base(theMessage)
        {
        }

        public TSComponentOne(IMessage theMessage, string description)
            : base(theMessage, description)
        {
        }

        #endregion

        #region Public Properties

        /// <summary> Returns the day as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Day
        {
            get
            {
                return this.Detail.Day;
            }
        }

        /// <summary> Returns the fractional second value as a float.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual float FractSecond
        {
            get
            {
                return this.Detail.FractSecond;
            }
        }

        /// <summary> Returns the GMT offset value as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int GMTOffset
        {
            get
            {
                return this.Detail.GMTOffset;
            }

            /// <summary>Returns the name of the type (used in XML encoding and profile checking)  </summary>
            //    public String getName() {
            //        return "NM"; //seems to be called an NM in XML representation prior to 2.5  
            //    }
        }

        /// <summary> Returns the hour as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Hour
        {
            get
            {
                return this.Detail.Hour;
            }
        }

        /// <summary> Returns the minute as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Minute
        {
            get
            {
                return this.Detail.Minute;
            }
        }

        /// <summary> Returns the month as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Month
        {
            get
            {
                return this.Detail.Month;
            }
        }

        /// <seealso cref="CommonTS.setOffset(int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Offset
        {
            set
            {
                this.Detail.Offset = value;
            }
        }

        /// <summary> Returns the second as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Second
        {
            get
            {
                return this.Detail.Second;
            }
        }

        /// <throws>  DataTypeException if the value is incorrectly formatted and either validation is  </throws>
        /// <summary>      enabled for this primitive or detail setters / getters have been called, forcing further
        /// parsing.   
        /// </summary>
        public override System.String Value
        {
            get
            {
                System.String result = base.Value;

                if (this.myDetail != null)
                {
                    result = this.myDetail.Value;
                }

                return result;
            }

            set
            {
                base.Value = value;

                if (this.myDetail != null)
                {
                    this.myDetail.Value = value;
                }
            }
        }

        /// <summary> Returns the year as an integer.</summary>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual int Year
        {
            get
            {
                return this.Detail.Year;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute)
        /// </summary>
        protected virtual string LongDateTimeFormat
        {
            get
            {
                return "yyyyMMddHHmm";
            }
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute, Second, Fraction of second)
        /// </summary>
        protected virtual string LongDateTimeFormatWithFactionOfSecond
        {
            get
            {
                return "yyyyMMddHHmmss.FFFF";
            }
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute, Second)
        /// </summary>
        protected virtual string LongDateTimeFormatWithSecond
        {
            get
            {
                return "yyyyMMddHHmmss";
            }
        }

        /// <summary>
        /// Used for setting the format of a short date (Year, Month, Day)
        /// </summary>
        protected virtual string ShortDateTimeFormat
        {
            get
            {
                return "yyyyMMdd";
            }
        }

        private CommonTS Detail
        {
            get
            {
                if (this.myDetail == null)
                {
                    this.myDetail = new CommonTS(this.Value);
                }
                return this.myDetail;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get the value as a date.  Throws hl7Exception if error.
        /// </summary>
        /// <returns>Data/Time</returns>
        public virtual DateTime GetAsDate()
        {
            try
            {
                string[] dateFormats =
                {
                    this.LongDateTimeFormat, this.ShortDateTimeFormat,
                    this.LongDateTimeFormatWithSecond
                };
                DateTime val = DateTime.MinValue;
                System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                if (this.Value != null && this.Value.Length > 0)
                {
                    val = DateTime.ParseExact(
                        this.Value,
                        dateFormats,
                        culture,
                        System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                }
                return val;
            }
            catch (Exception)
            {
                throw new HL7Exception("Could not get field as dateTime");
            }
        }

        /// <summary>
        /// Sets the value (to the format specified) using a date.
        /// </summary>
        /// <param name="value">Valid date/time</param>
        /// <param name="format">The format to set the value (yyyyMMdd, etc)</param>
        public virtual void Set(DateTime value, string format)
        {
            try
            {
                this.Value = value.ToString(format);
            }
            catch (FormatException)
            {
                throw new HL7Exception(
                    "Could not format the date " + value + " to a long date.  Format must be " + this.LongDateTimeFormat);
            }
        }

        /// <summary>
        /// Set the value as a long date
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDate(DateTime value)
        {
            this.Set(value, this.LongDateTimeFormat);
        }

        /// <summary>
        /// Set the value as a lond date with fraction of second
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDateWithFractionOfSecond(DateTime value)
        {
            this.Set(value, this.LongDateTimeFormatWithFactionOfSecond);
        }

        /// <summary>
        /// Set the value as a lond date with second
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDateWithSecond(DateTime value)
        {
            this.Set(value, this.LongDateTimeFormatWithSecond);
        }

        /// <summary>
        /// Set the value as a short date
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetShortDate(DateTime value)
        {
            this.Set(value, this.ShortDateTimeFormat);
        }

        /// <seealso cref="CommonTS.setDateMinutePrecision(int, int, int, int, int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual void setDateMinutePrecision(int yr, int mnth, int dy, int hr, int min)
        {
            this.Detail.setDateMinutePrecision(yr, mnth, dy, hr, min);
        }

        /// <seealso cref="CommonTS.setDatePrecision(int, int, int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual void setDatePrecision(int yr, int mnth, int dy)
        {
            this.Detail.setDatePrecision(yr, mnth, dy);
        }

        /// <seealso cref="CommonTS.setDateSecondPrecision(int, int, int, int, int, float)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
        /// this method is called.  
        /// </summary>
        public virtual void setDateSecondPrecision(int yr, int mnth, int dy, int hr, int min, float sec)
        {
            this.Detail.setDateSecondPrecision(yr, mnth, dy, hr, min, sec);
        }

        #endregion
    }
}