namespace SpiritualCare.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpiritualCare.Data.SpiritualCareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SpiritualCare.Data.SpiritualCareContext context)
        {
            context.L_AddressTypes.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Address { Created = DateTime.Now, Modified = DateTime.Now, Value = "منزل", Description = "عنوان منزل"},
                new Model.Lookup.L_Address { Created = DateTime.Now, Modified = DateTime.Now, Value = "منزل الاب", Description = "عنوان منزل الاب" }
                );
            
            context.L_Churches.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Church { Created = DateTime.Now, Modified = DateTime.Now, Value = "الشهيد العظيم مار جرجس بالجيوشي بشبرا", Description = "كنيسة الشهيد العظيم مار جرجس بالجيوشي بشبرا القاهرة" },
                 new Model.Lookup.L_Church { Created = DateTime.Now, Modified = DateTime.Now, Value = "السيدة العذراء مريم بالوجوه بشبرا", Description = "كنيسة السيدة العذراء مريم بالوجوه بشبرا القاهرة" },
                  new Model.Lookup.L_Church { Created = DateTime.Now, Modified = DateTime.Now, Value = "الشهيد العظيم ابي سيفين والشهيدة العفيفة دميانة", Description = "كنيسة الشهيد العظيم مرقوريوس ابي سيفين والشهيدة العفيفة دميانة بشبرا القاهرة" },
                   new Model.Lookup.L_Church { Created = DateTime.Now, Modified = DateTime.Now, Value = "القديس الانبا انطونيوس بشبرا", Description = "كنيسة القديس الانبا انطونيوس بشبرا القاهرة" }
                );
            
            context.L_ChurchServices.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_ChurchService { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار يعقوب - ابتدائي", Description = "اسرة مار يعقوب - ابتدائي" },
                new Model.Lookup.L_ChurchService { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار مرقس - اعدادي", Description = "اسرة مار مرقس - اعدادي" },
                new Model.Lookup.L_ChurchService { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار يوحنا - ثانوي", Description = "اسرة مار يوحنا - ثانوي" },
                new Model.Lookup.L_ChurchService { Created = DateTime.Now, Modified = DateTime.Now, Value = "بولس الرسول - جامعة", Description = "اسرة بولس الرسول - جامعة" }
                );

            context.L_Cities.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_City { Created = DateTime.Now, Modified = DateTime.Now, Value = "القاهرة"}
                );

            context.L_ContactMeans.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_ContactMean { Created = DateTime.Now, Modified = DateTime.Now, Value = "زيارة منزلية"},
                new Model.Lookup.L_ContactMean { Created = DateTime.Now, Modified = DateTime.Now, Value = "مكالمة تليفونية" },
                new Model.Lookup.L_ContactMean { Created = DateTime.Now, Modified = DateTime.Now, Value = "رسالة قصيرة" }
                );

            context.L_ContactSorts.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_ContactSort { Created = DateTime.Now, Modified = DateTime.Now, Value = "Google ID" },
                new Model.Lookup.L_ContactSort { Created = DateTime.Now, Modified = DateTime.Now, Value = "Yahoo ID" }
                );

            context.L_Countries.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Country { Created = DateTime.Now, Modified = DateTime.Now, Value = "مصر"}
                );

            context.L_Dioceses.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Diocese { Created = DateTime.Now, Modified = DateTime.Now, Value = "شبرا الجنوبية"}
                );

            context.L_EducationKinds.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Education { Created = DateTime.Now, Modified = DateTime.Now, Value = "ابتدائي" },
                new Model.Lookup.L_Education { Created = DateTime.Now, Modified = DateTime.Now, Value = "اعدادي" },
                new Model.Lookup.L_Education { Created = DateTime.Now, Modified = DateTime.Now, Value = "ثانوي" },
                new Model.Lookup.L_Education { Created = DateTime.Now, Modified = DateTime.Now, Value = "جامعة" },
                new Model.Lookup.L_Education { Created = DateTime.Now, Modified = DateTime.Now, Value = "فني" }
                );

            context.L_FamilyRoles.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "اب" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "ام" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "اخ" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "اخت" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "جد" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "جدة" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "زوج" },
                new Model.Lookup.L_FamilyRole { Created = DateTime.Now, Modified = DateTime.Now, Value = "زوجة" }
                );

            context.L_Fathers.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "صليب متى ساويرس" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "يوحنا نيروز" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "ابرام جرجس" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "اثناسيوس" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "ميخائيل عطية" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "موسى سعد" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "اسطفانوس ناروز" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "صموئيل حبيب" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "بولا" },
                new Model.Lookup.L_Father { Created = DateTime.Now, Modified = DateTime.Now, Value = "ارساني" }
                );

            context.L_Jobs.AddOrUpdate(
                new Model.Lookup.L_Job { Created = DateTime.Now, Modified = DateTime.Now, Value = "مدرس" },
                new Model.Lookup.L_Job { Created = DateTime.Now, Modified = DateTime.Now, Value = "طبيب" },
                new Model.Lookup.L_Job { Created = DateTime.Now, Modified = DateTime.Now, Value = "محامي" },
                new Model.Lookup.L_Job { Created = DateTime.Now, Modified = DateTime.Now, Value = "مهندس" },
                new Model.Lookup.L_Job { Created = DateTime.Now, Modified = DateTime.Now, Value = "ميكانيكي" }
                );

            context.L_Meetings.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Meeting { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار يعقوب - ابتدائي", Description = "اسرة مار يعقوب - ابتدائي" },
                new Model.Lookup.L_Meeting { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار مرقس - اعدادي", Description = "اسرة مار مرقس - اعدادي" },
                new Model.Lookup.L_Meeting { Created = DateTime.Now, Modified = DateTime.Now, Value = "مار يوحنا - ثانوي", Description = "اسرة مار يوحنا - ثانوي" },
                new Model.Lookup.L_Meeting { Created = DateTime.Now, Modified = DateTime.Now, Value = "بولس الرسول - جامعة", Description = "اسرة بولس الرسول - جامعة" },
                new Model.Lookup.L_Meeting { Created = DateTime.Now, Modified = DateTime.Now, Value = "الرسل - خدام", Description = "اسرة بولس الرسول - جامعة" }
                );

            context.L_Professions.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Profession { Created = DateTime.Now, Modified = DateTime.Now, Value = "مدرس" },
                new Model.Lookup.L_Profession { Created = DateTime.Now, Modified = DateTime.Now, Value = "طبيب" },
                new Model.Lookup.L_Profession { Created = DateTime.Now, Modified = DateTime.Now, Value = "محامي" },
                new Model.Lookup.L_Profession { Created = DateTime.Now, Modified = DateTime.Now, Value = "مهندس" },
                new Model.Lookup.L_Profession { Created = DateTime.Now, Modified = DateTime.Now, Value = "ميكانيكي" }
                );

            context.L_SocialStatuses.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_SocialStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "اعزب" },
                new Model.Lookup.L_SocialStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "متزوج" },
                new Model.Lookup.L_SocialStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "ارمل" }
                );

            context.L_Streets.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_Street { Created = DateTime.Now, Modified = DateTime.Now, Value = "الجيوشي" },
                new Model.Lookup.L_Street { Created = DateTime.Now, Modified = DateTime.Now, Value = "السيد مبروك" },
                new Model.Lookup.L_Street { Created = DateTime.Now, Modified = DateTime.Now, Value = "انيس داود" }
                );

            context.L_TaskStatuses.AddOrUpdate(
                l => l.Value,
                new Model.Lookup.L_TaskStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "لم تبدا"},
                new Model.Lookup.L_TaskStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "فعالة" },
                new Model.Lookup.L_TaskStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "اكتملت" },
                new Model.Lookup.L_TaskStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "منتظرة" },
                new Model.Lookup.L_TaskStatus { Created = DateTime.Now, Modified = DateTime.Now, Value = "الغيت" }
                );

    
        }
    }
}
