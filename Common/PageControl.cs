using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public static class PageControl
    {
        /// <summary>
        /// 同步分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="numEdge"></param>
        /// <param name="numDisplays"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="currentPage"></param>
        /// <param name="linkUrl"></param>
        /// <param name="firstText"></param>
        /// <param name="prevText"></param>
        /// <param name="nextText"></param>
        /// <param name="lastText"></param>
        /// <param name="showGo"></param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, int numEdge, int numDisplays, int pagesize, int count, int currentPage,
            string linkUrl, string firstText, string prevText, string nextText, string lastText, bool showGo = false)
        {
            if (count <= 0)
            {
                return string.Empty;
            }

            StringBuilder sbHtml = new StringBuilder();
            int m_totalCount = count < 0 ? 1 : count;
            int m_pageSize = pagesize < 0 ? 1 : pagesize;
            int start = 0, end = 0;
            int m_totalPage = Convert.ToInt32(Math.Ceiling(m_totalCount * 1.0 / m_pageSize));
            GetStartEnd(numDisplays, m_totalPage, currentPage, ref start, ref end);

            if (!string.IsNullOrEmpty(firstText) && (currentPage > 0))
            {
                sbHtml.Append(AppendItem(0, m_totalPage, currentPage, firstText, "prev disabled", linkUrl));
            }

            if (!string.IsNullOrEmpty(prevText) && (currentPage > 0))
            {
                sbHtml.Append(AppendItem(currentPage - 1, m_totalPage, currentPage, "<em></em>" + prevText, "prev", linkUrl));
            }

            if (start > 0 && numEdge > 0)
            {
                int _end = Math.Min(numEdge, start);
                for (var i = 1; i <= _end; i++)
                {
                    sbHtml.Append(AppendItem(i, m_totalPage, currentPage, null, null, linkUrl));
                }
                if (numEdge < start)
                {
                    sbHtml.Append("<span>...</span>");
                }
            }

            for (var i = start + 1; i <= end; i++)
            {
                sbHtml.Append(AppendItem(i, m_totalPage, currentPage, null, null, linkUrl));
            }

            if (end < m_totalPage && numEdge > 0)
            {
                if (m_totalPage - numEdge > end)
                {
                    sbHtml.Append("<span>...</span>");
                }
                int _begin = Math.Max(m_totalPage - numEdge, end);
                for (var i = _begin + 1; i <= m_totalPage; i++)
                {
                    sbHtml.Append(AppendItem(i, m_totalPage, currentPage, null, null, linkUrl));
                }
            }

            if (!string.IsNullOrEmpty(nextText) && (currentPage < m_totalPage ))
            {
                sbHtml.Append(AppendItem(currentPage + 1, m_totalPage, currentPage, nextText + "<em></em>", "next", linkUrl));
            }

            if (!string.IsNullOrEmpty(lastText) && (currentPage < m_totalPage))
            {
                sbHtml.Append(AppendItem(m_totalPage, m_totalPage, currentPage, lastText, "prev disabled", linkUrl));
            }
            if (!string.IsNullOrEmpty(lastText) && (currentPage == m_totalPage))
            {
                sbHtml.Append(AppendItem(currentPage + 1, m_totalPage, currentPage, nextText + "<em></em>", "next", linkUrl));
                sbHtml.Append(AppendItem(m_totalPage, m_totalPage, currentPage, lastText, "prev disabled", linkUrl));
            }

            if (showGo)
            {
                string gospan = "<input type=\"text\" onkeyup=\"this.value=this.value.replace(/\\D/g, '');\"";
                gospan += " onkeydown =\"var e = e || event, key = e.keyCode || e.which; if (key == 13) {jQuery(this).parent().children(':button').click();} \">";
                gospan += "<input type=\"button\" value=\"GO\" onclick =\"var val = Number(jQuery(this).parent().children(':text').val()); if (isNaN(val) || val < 0){val = 1;}else if (val > " + m_totalPage + "){val = " + m_totalPage + ";}window.location.href = '" + linkUrl + "'.replace('__id__', val); \">";
                sbHtml.Append(gospan);
            }
            return sbHtml.ToString();
        }

        private static string AppendItem(int page, int totalPage, int currentPage, string text, string css, string linkUrl)
        {
            string _html = string.Empty;
            int _page = page < 1 ? 1 : (page <= totalPage ? page : totalPage);
            string _text = string.IsNullOrEmpty(text) ? page.ToString() : text;
            string _css = css;
            if (_page == currentPage)
            {
                _html = "<span class='current'>" + _text + "</span>";
            }
            else
            {
                linkUrl = linkUrl.Replace("__id__", _page.ToString());                
                if (!string.IsNullOrEmpty(css))
                {
                    css = "class=\"" + css + "\"";
                }
                _html = "<a " + css + " href=\"" + linkUrl + "\">" + _text + "</a>";
            }
            return _html;
        }

        private static void GetStartEnd(int numDisplay, int totalPage, int currentPage, ref int start, ref int end)
        {
            int neHalf = Convert.ToInt32(Math.Ceiling(numDisplay * 1.0 / 2));
            int np = totalPage;
            int upperLimit = np - numDisplay;
            start = currentPage > neHalf ? Math.Max(Math.Min(currentPage - neHalf, upperLimit), 0) : 0;
            end = currentPage > neHalf ? Math.Min(currentPage + neHalf, np) : Math.Min(numDisplay, np);
        }
    }
}
