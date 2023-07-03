using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPortal.Common
{
    public static class EntityValidationConstants
    {
        public static class Make
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
        }
        public static class Model
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public static class EngineType
        {
            public const int TypeMinLength = 3;
            public const int TypeMaxLength = 20;
        }

        public static class Condition
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
        }

        public static class Color
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public static class Car
        {
            public const int MinYearManufacture = 1886;
            public const int MaxYearManufacture = 2023;
        }

        public static class Region
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 30;
        }

        public static class Offer
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 100;
            public const int DescriptionMaxLength = 1000;
        }

        public static class Image
        {
            public const int PathMinLength = 1;
            public const int PathMaxLength = 256;
        }
    }
}
