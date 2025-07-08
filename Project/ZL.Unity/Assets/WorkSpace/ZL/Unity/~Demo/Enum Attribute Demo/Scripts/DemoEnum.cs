namespace ZL.Unity.Demo.EnumAttributeDemo
{
    public enum DemoEnum
    {
        [EnumBool(false)]

        Bool,

        [EnumInt(1)]

        Int,

        [EnumFloat(2f)]

        Float,

        [EnumString("3")]

        String,

        [EnumColor("#FF0000")]

        RedColor,

        [EnumColor("#00FF00")]

        GreenColor,

        [EnumColor("#0000FF")]

        BlueColor,
    }
}