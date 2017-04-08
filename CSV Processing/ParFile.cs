using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace CSVtoPARNamespace {
	/*	#pragma pack(1)
	struct PARS_OF_WRITE_FILE
	{
	(-)  char Code [20];//20 байт- «3571090,7859525»
	(-)  char PlataName[17]; // 17 байт – название платы
	(текущая дата)  char TimeString[26]; // 26 байт – число и время завершения ввода данных
	(32)  WORD ChannelsMax; // 2 байта – общее число каналов для выбранной платы
	(32)  WORD RealChannelsQuantity; // 2 байта – число введенных (активных) каналов
	(-)  int RealKadrsQuantity; // 4 байта – устаревший параметр
	(-)  int RealSamplesQuantity; // 4 байта – устаревший кадр
	(кол-во строк)  double TotalTime; // 8 байт – время ввода в секундах в формате ‘DOUBLE’
	(20)  float AdcRate; // 4 байта – частота АЦП в кГц в формате ‘FLOAT’
	(-)  float InterkadrDelay; // 4 байта – межкадровая задержка в мс в формате ‘FLOAT’
	(20/32)  float ChannelRate; // 4 байта – частота сбора данных с одного канала в кГц в формате ‘FLOAT’
	(1)  bool ActiveAdcChannelArray[32]; // 1 байт *32 – массив , каждый элемент которого равен нулю или единице, единичное значение соответствует тому, что данный вход активен 
	(1....32)  BYTE AdcChannelArray[32]; // 1 байт *32- массив, каждый элемент которого равен номеру канала АЦП для соответствующего входа 
	(0)  BYTE AdcGainArray[32]; // 1 байт*32-массив, каждый элемент которого равен индексу коэффициенту  усиления(0,1,2 или 3)
	(0)  BYTE IsSignalArray[32]; // 1 байт*31-массив, каждый элемент которого равен 0 или 1, единичное значение соответствует тому, что данный канал был заземлён на плате
	(3)  int DataFormat; // 4 байта-формат данных, равен 3
	(кол-во строк)  long long RealKadrs64; // 8 байт, число собранных кадров в 8-байтном формате 
	(0)  double AdcOffset[32]; // 8 байт, коэффициенты смещения для подключенной платы АЦП( считываются из Flash памяти АЦП)
	(1)  double AdcScale[32]; // 8 байт, , коэффициенты масштаба для подключенной платы АЦП( считываются из Flash памяти АЦП)
	(1)  double CalibrScale[1024]; // 8 байт, пользовательские коэффициенты масштаба
	(0)  double CalibrOffset[1024]; // 8 байт, пользовательские коэффициенты смещения 
	(1)  int Segments; // число сегментов файла данных
	};
	#pragma pack()*/
	static internal class ParFile {
		static private string filename;

		internal static string Filename {
			get { return ParFile.filename; }
			set { ParFile.filename = value.Substring(0, value.LastIndexOf('.')) + ".par"; }
		}

		static internal void SaveFile() {
			using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create), Encoding.ASCII)) {
				bw.Write("3571090,7859525".ToCharArray());//20 байт символов.
				bw.Seek(19, SeekOrigin.Begin);//Смещение на 21 байт

				/*17 байт названия платы. В данном случае в строке будет 14 байт,
				 * но это корректируется последующим переходом на определённую позицию,
				 * чтобы сохранить структуру*/
				bw.Write("PlataName".ToCharArray());
				bw.Seek(37, SeekOrigin.Begin);//Смещение на 37 байт

				//Запись даты
				bw.Write(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.GetCultureInfo("en-us")));
				bw.Seek(62, SeekOrigin.Begin);//Смещение на 63 байта
				//Запись общего числа каналов для выбранной платы
				bw.Write((Int16)32);
				//Запись числа введённых (активных) каналов
				bw.Write((Int16)32);

				/*Следующие два параметра можно не писать, а сразу перейти на 8 байт
				 *bw.Seek(8, SeekOrigin.Current). Но для лучшего понимания, что происходит
				 *запишем и их.*/
				//Устаревший параметр
				bw.Write(0xFFFF);
				//Устаревший кадр
				bw.Write(0xFFFF);
				
			}
		}
		static private void WriteHeader(BinaryWriter bw) {

		}
	}
}
