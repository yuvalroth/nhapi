using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25.Datatype
{
/// <summary>
/// <p>The HL7 MO (Money) data type.  Consists of the following components: </p><ol>
/// <li>Quantity (NM)</li>
/// <li>Denomination (ID)</li>
/// </ol>
/// </summary>

[Serializable]
public class MO : AbstractType, IComposite{
    /// <summary>   The data. </summary>
	private IType[] data;

    /// <summary>   Creates a MO. </summary>
    ///
    /// <param name="message">  The Message to which this Type belongs. </param>

	public MO(IMessage message) : this(message, null){}

    /// <summary>   Creates a MO. </summary>
    ///
    /// <param name="message">      The Message to which this Type belongs. </param>
    /// <param name="description">  The description of this type. </param>

	public MO(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new NM(message,"Quantity");
		data[1] = new ID(message, 0,"Denomination");
	}

    /// <summary>   Returns an array containing the data elements. </summary>
    ///
    /// <value> The components. </value>

	public IType[] Components
	{ 
		get{
			return this.data; 
		}
	}

    /// <summary>
    /// Returns an individual data component.
    /// @throws DataTypeException if the given element number is out of range.
    /// </summary>
    ///
    /// <param name="index">    The index item to get (zero based) </param>
    ///
    /// <returns>   The data component (as a type) at the requested number (ordinal) </returns>

	public IType this[int index] { 

get{
		try { 
			return this.data[index]; 
		} catch (System.ArgumentOutOfRangeException) { 
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element MO composite"); 
		} 
	} 
	} 

    /// <summary>
    /// Returns Quantity (component #0).  This is a convenience method that saves you from casting
    /// and handling an exception.
    /// </summary>
    ///
    /// <value> The quantity. </value>

	public NM Quantity {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}

    /// <summary>
    /// Returns Denomination (component #1).  This is a convenience method that saves you from
    /// casting and handling an exception.
    /// </summary>
    ///
    /// <value> The denomination. </value>

	public ID Denomination {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}