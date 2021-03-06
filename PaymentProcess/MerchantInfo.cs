//-----------------------------------------------------------------------
// <copyright file="MerchantInfo.cs" company="Mission3, Inc.">
//      Copyright (c) Mission3, Inc. All rights reserved.
//
//      Permission is hereby granted, free of charge, to any person
//      obtaining a copy of this software and associated documentation
//      files (the "Software"), to deal in the Software without
//      restriction, including without limitation the rights to use,
//      copy, modify, merge, publish, distribute, sublicense, and/or sell
//      copies of the Software, and to permit persons to whom the
//      Software is furnished to do so, subject to the following
//      conditions:
//
//      The above copyright notice and this permission notice shall be
//      included in all copies or substantial portions of the Software.
//
//      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//      EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//      OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//      NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//      HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//      WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//      FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//      OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text;

namespace PaymentProcess
{
    /// <summary>
    /// Merchant information
    /// </summary>
    public class MerchantInfo : IInfo
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Merchant login
        /// </summary>
        private string login;

        /// <summary>
        /// Merchant transaction key
        /// </summary>
        private string tranKey;

        /// <summary>
        /// MerchantInfo CTor
        /// </summary>
        /// <param name="login">Merchant login</param>
        /// <param name="tran_key">Merchant transaction key</param>
        public MerchantInfo(string login, string tran_key)
        {
            Trace.WriteLineIf(ts.TraceInfo, "MerchantInfo - CTor (string, string)");
            this.login = login;
            tranKey = tran_key;
        }

        /// <summary>
        /// Gets or sets the merchant login
        /// </summary>
        public string X_Login
        {
            get { return login; }
            set { login = value; }
        }

        /// <summary>
        /// Gets or sets teh merchant transaction key
        /// </summary>
        public string X_Tran_Key
        {
            get { return tranKey; }
            set { tranKey = value; }
        }

        #region IInfo Members

        /// <summary>
        /// Builds the HTTP POST string for AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "MerchantInfo - ToString start");

            var sb = new StringBuilder();
            sb.Append("&x_login=" + login);
            sb.Append("&x_tran_key=" + tranKey);

            Trace.WriteLineIf(ts.TraceInfo, "Stringbuilder value to return: " + sb);
            Trace.WriteLineIf(ts.TraceInfo, "MerchantInfo - ToString end");

            return sb.ToString();
        }

        #endregion
    }
}