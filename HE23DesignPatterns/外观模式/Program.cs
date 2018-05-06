using System;

namespace DesignMethod.外观模式
{
    public class Program : OpenDesign
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        public override void Open()
        {
            if (facade.RegistrationCourse("设计模式", "Lear"))
            {
                Console.WriteLine("选课成功");
            }
            else
                Console.WriteLine("选课失败");
            Console.Read();
        }
    }
}