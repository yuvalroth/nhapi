/*
* HapiLog.java
* 
* Created on May 7, 2003 at 3:53:44 PM
*/

namespace NHapi.Base.Log
{
    /// <summary>
    /// A logging interface that enhances the <code> Log </code>
    /// interface with ancillary method to easy up the log messages generation by adding
    /// MessageFormat like functionality.
    /// 
    /// Instantiate using {@link HapiLogFactory#getLog( Class clazz)}
    /// or {@link HapiLogFactory#getLog( String name)}
    /// 
    /// <pre>
    /// USASE PATTERN:
    /// (look at the jakarta-commons-logging and log4j documentation first)
    /// 
    /// ...
    /// import ca.uhn.log.*;
    /// ...
    /// class A {
    /// private static final HapiLog log = HapiLogFactory.getHapiLog( A.class );
    /// 
    /// public boolean methodA( Object param1 ) {
    /// boolean retVal = true;
    /// 
    /// //log debug messages (to be printed only when the debug mode is specified
    /// //in the configuration file)
    /// log.debug( "param1 = " + param1 );
    /// 
    /// Object copy = null;
    /// try {
    /// copy = param1.clone();
    /// }
    /// catch( CloneNotSupportedException e ) {
    /// //log the error
    /// log.error( "param1 must be cloneable", e );
    /// retVal = false;
    /// }
    /// 
    /// log.debug( "retVal = " + retVal );
    /// return retVal;
    /// }
    /// 
    /// ...
    /// 
    /// }
    /// </pre>
    /// </summary>

    public interface IHapiLog : ILog
    {
        #region Public Methods and Operators

        /// <summary>   debug method. </summary>
        ///
        /// <param name="msgPattern">   . </param>
        /// <param name="values">       . </param>
        /// <param name="e">            . </param>

        void Debug(System.String msgPattern, System.Object[] values, System.Exception e);

        #endregion
    }
}