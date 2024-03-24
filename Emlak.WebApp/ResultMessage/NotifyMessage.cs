namespace Emlak.WebApp.ResultMessage
{
    public static class NotifyMessage
    {
        public static class Advert
        {
            public static string Add(string advertTitle)
            {
                return $"{advertTitle} Başarılı bir şekilde eklendi";
            }

            public static string Update(string advertTitle)
            {
                return $"{advertTitle} başarıyla güncellenmiştir";
            }

            public static string Delete(string advertTitle)
            {
                return $"{advertTitle} başarıyla silinmiştir";
            }

            public static string Warning(string advertTitle)
            {
                return $"{advertTitle} Kontrol edilmesi gerekiyor";
            }

            public static string UndoDelete(string advertTitle)
            {
                return $"{advertTitle} başarıyla geri alınmıştır";
            }
        }

        public static class Images
        {
            public static string Add(string imagesName)
            {
                return $"{imagesName} Başarılı bir şekilde eklendi";
            }

            public static string Update(string imagesName)
            {
                return $"{imagesName} başarıyla güncellenmiştir";
            }

            public static string Delete(string imagesName)
            {
                return $"{imagesName} başarıyla silinmiştir";
            }

            public static string Warning(string imagesName)
            {
                return $"{imagesName} Kontrol edilmesi gerekiyor";
            }

            public static string UndoDelete(string imagesName)
            {
                return $"{imagesName} başarıyla geri alınmıştır";
            }
        }
    }
}
