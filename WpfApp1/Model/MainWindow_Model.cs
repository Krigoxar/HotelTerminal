using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Model
{
    public class MainWindow_Model
    {


        public static Dictionary<string, int> MaxRoomsАmount = new Dictionary<string, int>()
        {
            {"OneRoomed", 30},
            {"TwoRoomed", 20},
            {"ThreeRoomed", 10},
            {"VipRoomed", 5 }
        };
        public Dictionary<string, int> RoomsАmount;
        public MainWindow_Model()
        {
            OneRoomedcount = MaxRoomsАmount["OneRoomed"].ToString();
            TwoRoomedcount = MaxRoomsАmount["TwoRoomed"].ToString();
            ThreeRoomedcount = MaxRoomsАmount["ThreeRoomed"].ToString();
            VipRoomedcount = MaxRoomsАmount["VipRoomed"].ToString();
            RoomsАmount = new Dictionary<string, int>()
        {
            {"OneRoomed", 30},
            {"TwoRoomed", 20},
            {"ThreeRoomed", 10},
            {"VipRoomed", 5 }
        };
        }
        public void UpdateModel()
        {
            OneRoomedcount = RoomsАmount["OneRoomed"].ToString();
            TwoRoomedcount = RoomsАmount["TwoRoomed"].ToString();
            ThreeRoomedcount = RoomsАmount["ThreeRoomed"].ToString();
            VipRoomedcount = RoomsАmount["VipRoomed"].ToString();
        }
        public int[] MassivOfDates { get; set; }
        public string OneRoomedcount { get; set; }
        public string TwoRoomedcount { get; set; }
        public string ThreeRoomedcount { get; set; }
        public string VipRoomedcount { get; set; }
    }
}
