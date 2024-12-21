using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommers.Shared.ResponseDTOs
{
    public class ResponseDTO<T> // factern dizayn pattern 
    {
        // generic bir class olması gerekiyor çunku geriye dönen değer category, product yani ne denk gelirse onu dönecegi için T tipinde olması gerekir
        public T? Data { get; set; } // gelecek tip (T) generic 
        public List<string>? Errors { get; set; } // hata listesi

        [JsonIgnore]
        public bool IsSuccesded { get; set; }

        [JsonIgnore] // dışarıya göndermek istemedigim için.Jshone dönüştürürken ignor et dikkate alma!
        public int StatusCode { get; set; }// response code 200 , 201 

        public static ResponseDTO<T> Success(T data, int statusCode)  // Geriye veri döndüren başarılı istek sonucu cevabı.
        {
            return new ResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccesded = true
            };
        }
        //Geriye veri döndürmeyen başarılı cevap
        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T>
            {
                //Data=null, null olma ihtimali için T tipinin default deperini istiyoruz ama biz null olmadıgını biliyoruz.

                Data = default(T),
                StatusCode = statusCode,
                IsSuccesded = false
            };
        }
        // Tek hata döndüren başarısız cevap
        public static ResponseDTO<T> Fail(string error, int statusCode) // hata oldugu içib dataya karışmıyoruz
        {
            return new ResponseDTO<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode,
                IsSuccesded = false
            };
        }

        // Birden dazla hata döndüren başarısız hata
        public static ResponseDTO<T> Fail(List<string> errors, int statusCode) // hata oldugu içib dataya karışmıyoruz
        {
            return new ResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccesded = false

            };
        }
    }
}
