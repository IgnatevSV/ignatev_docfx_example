namespace DocFX_Example
{
    /// <summary>
    /// Описание класса DocFX_Example_Class.
    /// </summary>
    public class DocFX_Example_Class
    {
        /// <summary>
        /// Описание public переменной.
        /// </summary>
        public bool publicVar;


        /// <summary>
        /// Описание protected переменной.
        /// </summary>
        protected bool protectedVar;


        /// <summary>
        /// Описание свойства.
        /// </summary>
        public bool PropertyExample
        {
            get;
            private set;
        }


        /// <summary>
        /// Описание public метода.
        /// </summary>
        public virtual void publicMethod() { }


        /// <summary>
        /// Описание protected метода.
        /// </summary>
        protected virtual void ProtectedMethod() { }


        /// <summary>
        /// Описание protected internal метода.
        /// </summary>
        protected virtual internal void ProtectedInternalMethod() { }


        /// <summary>
        /// Описание метода.
        /// </summary>
        /// <param name="value">Описание параметров.</param>
        /// <returns>Описание возвращаемых значений.</returns>
        /// 
        /// <example>Пример кода с использование данного метода.
        /// <code language="c#">
        /// Участок кода
        /// </code>
        /// </example>
        /// 
        /// <remarks>Описание ремарки.</remarks>
        public virtual bool SimpleExampleMethod(bool value)
        {
            return true;
        }
    }
}