# CodeRunner - CodN Language IDE

یک محیط توسعه یکپارچه (IDE) برای زبان برنامه‌نویسی اختصاصی **CodN** و **#C**

## 📋 ویژگی‌ها

### زبان CodN
- **ترکیب نحو**: تلفیقی از Pascal و C# با سینتکس ساده
- **انواع داده**: 
  - `Int` - اعداد صحیح
  - `Double` - اعداد اعشاری
  - `String` - رشته‌ها
  - `Bool` - مقادیر منطقی
  - `Byte` - اعداد بایتی

- **ساختارهای کنترلی**:
  - شرطی: `If ... Then ... Else`
  - حلقه‌ها: `For`, `Mfor` (نزولی), `While`
  - بلوک کد: `Begin ... End`

- **ورودی/خروجی**:
  - `Write()` - نمایش خروجی
  - `Read()` - خواندن کاراکتر
  - `ReadLine()` - خواندن خط

- **تعریف تابع**:
  ```codn
  Fanction functionName
  Input : parameter.Int;
  Output : Int
  Begin
    Return parameter + 1;
  End
  ```

### قابلیت‌های IDE
- ✅ ویرایشگر کد با رنگ‌آمیزی_syntax_
- ✅ کامپایلر بلادرنگ CodN به #C
- ✅ مدیریت خطاهای کامپایل
- ✅ اجرای مستقیم برنامه
- ✅ خروجی EXE
- ✅ پشتیبانی از چندین فایل
- ✅ جدول نمادهای پیشرفته با Scope‌های تو در تو

## 🚀 نصب و اجرا

### پیش‌نیازها
- .NET Framework 4.5 یا بالاتر
- Java Runtime (برای ANTLR)

### ساخت پروژه
```bash
# باز کردن در Visual Studio
CodeRuner.sln

# یا استفاده از MSBuild
msbuild CodeRuner.sln /p:Configuration=Release
```

## 📝 مثال کد CodN

```codn
%% این یک برنامه نمونه است
Fanction main
Output : Int
Begin
  x.Int;
  x = 5;
  Write(x);
  If x > 0 Then Begin
    Write("Positive");
  End;
  Return 0;
End
```

## 🏗️ ساختار پروژه

```
CodeRuner/
├── Compailer/          # کامپایلر و تحلیلگر
│   ├── sample.g        # گرامر ANTLR
│   ├── Scope.cs        # مدیریت Scope
│   └── ...             # فایل‌های تولید شده
├── Syntax/             # تعاریف Highlighting
│   ├── CN.xshd         #_syntax_ CodN
│   └── C#.xshd         #_syntax_ #C
├── MainWindow.xaml     # رابط کاربری
└── tabdil_noe.cs       # تبدیل انواع
```

## 🔧 بهبودهای انجام شده

### نسخه فعلی (v2.0)
- ✨ بازسازی کامل گرامر ANTLR با رفع ابهامات
- ✨ بهبود مدیریت خطاها و گزارش‌دهی
- ✨ جایگزینی Scope قدیمی با سیستم مدرن
- ✨ بهبود تبدیل انواع داده
- ✨ حذف API منسوخ شده کامپایلر
- ✨ اضافه کردن References لازم
- ✨ گزارش خطاهای بهتر با شماره خط
- ✨ مدیریت استثناهای کامل

### ویژگی‌های در دست توسعه
- [ ] IntelliSense و Auto-complete
- [ ] Debugger با Breakpoint
- [ ] مدیریت پروژه
- [ ] Templates کد
- [ ] Git Integration
- [ ] Refactoring tools

## 📄 مجوز

این پروژه برای اهداف آموزشی توسعه یافته است.

## 🤝 مشارکت

برای گزارش مشکلات یا پیشنهاد ویژگی‌های جدید، لطفاً Issue ایجاد کنید.

---

**توسعه‌دهنده**: CodeRunner Team  
**تاریخ**: 2024  
**زبان‌ها**: Persian/Farsi, English
