using OpenQA.Selenium;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Selenia.Core
{
    public abstract class AbstractSeleniaElement : RealProxy
    {
        protected AbstractSeleniaElement() : base(typeof(SeleniaElement)) { }

        protected abstract IWebElement Delegate { get; }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var method = methodCall.MethodBase as MethodInfo;

            object result = GetTransparentProxy() as SeleniaElement;
            if ("Value" == method.Name)
            {
                if (methodCall.ArgCount == 0)
                {
                    result = GetValue();
                }
                else
                {
                    SetValue(methodCall.Args[0] as string);
                }
            }
            else if ("Enter" == method.Name)
            {
                Delegate.SendKeys(Keys.Enter);
            }
            else if ("Exists" == method.Name)
            {
                result = Exists();
            }
            else if ("get_Displayed" == method.Name)
            {
                result = Displayed();
            }
            else if ("Append" == method.Name)
            {
                Delegate.SendKeys(methodCall.Args[0] as string);
            }
            else if ("get_Text" == method.Name)
            {
                result = Delegate.Text;
            }
            else if ("get_TagName" == method.Name)
            {
                result = Delegate.TagName;
            }

            return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
        }

        private string GetValue() => Delegate.GetAttribute("value");

        private void SetValue(string text)
        {
            Delegate.Clear();
            Delegate.SendKeys(text);
        }

        private bool Exists()
        {
            try
            {
                return Delegate != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool Displayed()
        {
            try
            {
                return Delegate != null && Delegate.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
