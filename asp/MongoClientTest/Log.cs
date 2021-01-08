using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace MongoClientTest.WebApp
{
    public static class Log
    {
        
        public static void Error([Localizable(false)] string message, params object[] parameters)
        {
            InternalLog("Err", message, parameters);
        }

        
        public static void General([Localizable(false)] string message, params object[] parameters)
        {
            InternalLog("Gen", message, parameters);
        }

        
        public static void Info([Localizable(false)] string message, params object[] parameters)
        {
            InternalLog("Inf", message, parameters);
        }

        
        public static void Debug([Localizable(false)] string message, params object[] parameters)
        {
            InternalLog("Deb", message, parameters);
        }

        public static void LogUnhandledExceptionMessage(Exception exception)
        {
            var builder = new StringBuilder();

            builder.AppendLine("UNHANDLED EXCEPTION");
            builder.AppendLine(ConvertToFormattedString(exception));

            if (exception is ReflectionTypeLoadException typeLoadException && 
                typeLoadException.LoaderExceptions != null && 
                typeLoadException.LoaderExceptions.Length > 0
                )
            {
                builder.AppendLine("LOAD EXCEPTIONS");

                foreach (var loadException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendLine(ConvertToFormattedString(loadException));
                    builder.AppendLine();
                }
            }
            
            Error(builder.ToString());
        }

        public static string ConvertToFormattedString(Exception exception)
        {
            var result = new StringBuilder();

            while (exception != null)
            {
                result.Append(exception.GetType().Name)
                    .Append(": ")
                    .AppendLine(exception.Message)
                    .AppendLine(exception.StackTrace);

                if (exception.InnerException != null)
                {
                    result.AppendLine()
                        .AppendLine("**** INNER EXCEPTION ****");
                }

                exception = exception.InnerException;
            }

            return result.ToString();
        }

        static void InternalLog(string prefix, string message, params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                message = String.Format(CultureInfo.InvariantCulture, message, parameters);
            }
            
            Console.WriteLine($@"{prefix}: {message}");
        }
    }
}
