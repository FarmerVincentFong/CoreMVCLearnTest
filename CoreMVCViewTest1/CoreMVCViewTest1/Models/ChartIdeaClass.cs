using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCViewTest1.Models
{
    public class ChartIdeaClass
    {
        //dal获取数据的接口

        public object GetChartData(int year)
        {
            //先设置中取正单类型的值，这些值的和 作为A单
            //与补单类型的值，这两个值分别作为B单，C单

            var AMonthCountArr = GetYearMonthOrderCountData(year, "A单的类型值");
            var BMonthCountArr = GetYearMonthOrderCountData(year, "B单的类型值");
            var CMonthCountArr = GetYearMonthOrderCountData(year, "C单的类型值");
            //将这些数据拼接起来，构造成占比

            //这里获取B单、C单的各补单原因，在各月的订单数
            var BReasonMonthCountArr = GetReasonMonthOrderCountData(year, "B单的类型值");
            var CReasonMonthCountArr = GetReasonMonthOrderCountData(year, "C单的类型值");

            //封成一个对象
            return new { };
        }

        //获取某年各月的A或B或C单的 订单数
        public List<object> GetYearMonthOrderCountData(int year, string typeNames)
        {
            //查视图的值

            //返回后，构造成按1到12月的数据。如[{month:1,count:10},{month:1,count:20}]
            return new List<object>();

        }

        //获取某年各月 B单或C单的各补单原因的 订单数
        public List<object> GetReasonMonthOrderCountData(int year, string typeNames)
        {
            //查视图的值

            //数据类似于[{month:1,reason:"设计",count:10},{month:1,reason:"工厂",count:14}
            //{month:2,reason:"生产",count:8},{month:4,reason:"设计",count:33}]

            //到时候在js中根据这些数据，构造出个按某年 各补单原因的 订单数
            //可直接显示在饼图上

            //此查询数据保存在js的变量中，方便点击事件动态更改饼图。（每次重新选年，刷新所有数据）
            return new List<object>();
        }

    }
}
