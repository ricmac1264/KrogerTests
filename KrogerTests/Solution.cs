using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KrogerTests
{
    public class Solution
    {
        private static List<Dictionary<string, object>> PersonalizeCoupons(List<Dictionary<string, Object>> coupons,
                                                                           List<string> preferredCategories)
        {
            List<Dictionary<string, Object>> myCoupons = new List<Dictionary<string, Object>>();
            foreach (Dictionary<string, Object> coupon in coupons)
            {
                foreach (string preferredCategory in preferredCategories) {
                    if (coupon["category"].Equals(preferredCategory)){
                        myCoupons.Add(coupon);
                    }
                }
            }

            myCoupons.OrderByDescending(coupon => ((float)coupon["couponAmount"]/(float)coupon["itemPrice"]));

            int i = 0;

            foreach (Dictionary<string, Object> coupon in myCoupons)
            {
                if (i < 10)
                {
                    coupon.Remove("code");
                }
                else
                {
                    myCoupons.RemoveAt(i);
                }
                i++;
            }
            return myCoupons;
        }

        private static Dictionary<string, Object> ReadCoupon(string input)
        {
            string[] couponItems = input.Split(',');

            var coupon = new Dictionary<string, Object>
            {
                { "upc", couponItems[0] },
                { "code", couponItems[1] },
                { "category", couponItems[2] },
                { "itemPrice", float.Parse(couponItems[3], CultureInfo.InvariantCulture) },
                { "couponAmount", float.Parse(couponItems[4], CultureInfo.InvariantCulture) }
            };
            return coupon;
        }
    }
}
