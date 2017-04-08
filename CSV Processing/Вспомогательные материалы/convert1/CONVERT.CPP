//=============================================================================
// Программа конвертации бинарных *.dat файлов L-Graph в текстовай формат *.txt
//=============================================================================

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <dos.h>
#include <ctype.h>
#include <conio.h>

struct PARS_OF_WRITE_FILE
{
	char Code[20];             // 20 байт  - "2571090,1618190     "
	char PlataName[17];        // 17 байт  - название платы
	char TimeString[26];       // 26 байт  - число и время завершения ввода данных
	int ChannelsMax;           // 2 байта  - общее число каналов для выбранной платы
	int RealChannelsQuantity;  // 2 байта  - число введенных (активных) каналов
	long  RealKadrsQuantity;   // 4 байта  - число собранных кадров в формате 'int' (< 2.147.483.648)
	long  RealSamplesQuantity; // 4 байта  - число собранных отсчетов в формате 'int' (< 2.147.483.648)
	double TotalTime;          // 8 байт   - время ввода в cекундах в формате 'DOUBLE'
	float AdcRate;             // 4 байта  - частота АЦП в кГц в формате 'FLOAT'
	float InterkadrDelay;      // 4 байта  - межкадровая задержка в млс в формате 'FLOAT'
	float ChannelRate;         // 4 байта  - частота сбора данных с одного канала в кГц в формате 'FLOAT'
	unsigned char  ActiveAdcChannelArray[32];	// 1байт*32 - массив, каждый элемент
															// которого равен нулю или единице, единичное значение
															// соответствует тому, что данный вход активен
	unsigned char  AdcChannelArray[32];	// 1байт*32 - массив, каждый элемент
													// которого равен номеру канала АЦП для соответствующего входа
	unsigned char  AdcGainArray[32];    //1байта*32 - массив, каждый элемент которого
													// равен индексу коэффициенту усиления (0,1,2 или 3)
	unsigned char  IsSignalArray[32];   //1байта*32 - массив, каждый элемент которого
													// которого равен нулю или единице, единичное значение
													// соответствует тому, что данный канал был заземлен на плате
};

//------------------------------------------------------------------------
// Основная программа
//------------------------------------------------------------------------
int main(int n_p, char **str_p)
{
	unsigned char sourcefile[20];
	unsigned char parsfile[20];
	unsigned char targetfile[20];
	char stroka[77], *endptr;
	int DataVal;
	unsigned long i, NPoints, error;
	FILE *fpsource, *fptarget, *fpfilepars;
	PARS_OF_WRITE_FILE DataPars;

	puts(	" File converter from 'bin' format to 'text' for L-Graph data files.\n"
			" Copyright (c) 2000 L-Card Ltd.\n"
			" Usage: convert.exe  [filename[.dat]]\n");

	if(n_p != 2) { puts("\n	------- ERROR1!!!\n\n"); exit(1); }

	// считаем название файла
	strcpy(sourcefile, str_p[n_p-1]);
	strcpy(parsfile, str_p[n_p-1]);
	strcpy(targetfile, str_p[n_p-1]);

	// файл исходных бинарных данных
	if(!(endptr=strchr(sourcefile,'.'))) strcat(sourcefile, ".dat");
	else { strlwr(endptr); if(strcmp(endptr, ".dat")) { puts("\n File extention must be '.dat'!"); exit(1); }	}

	// файл параметров файла данных
	if(!(endptr=strchr(parsfile,'.'))) strcat(parsfile, ".par");
	else { *endptr=0; strcat(parsfile, ".par"); }

	// файл конечных текстовых данных
	if(!(endptr=strchr(targetfile,'.'))) strcat(targetfile, ".txt");
	else { *endptr=0; strcat(targetfile, ".txt"); }

	fpsource=fopen(sourcefile, "rb");
	if(fpsource == NULL)	{ printf("\n  Can't find %s!\n", sourcefile);	exit(1); }

	fpfilepars=fopen(parsfile, "rb");
	if(fpfilepars == NULL)	{ printf("\n  Can't find %s!\n", parsfile);	exit(1); }

	fptarget=fopen(targetfile, "wt");
	if(fptarget == NULL)	{ printf("\n  Can't open %s!\n", targetfile); exit(1); }

	if(sizeof(PARS_OF_WRITE_FILE) != fread(&DataPars, 1, sizeof(PARS_OF_WRITE_FILE), fpfilepars))
		{ puts("\n	------- ERROR2!!!\n\n"); exit(1); }

// проверка файла *.par ??????

	NPoints=DataPars.RealSamplesQuantity;
	for(i=error=0; i < NPoints; i++)
	{
		fread(&DataVal, 2, 1, fpsource);
		sprintf(stroka, "%7i", DataVal);
		if(((long)(i+1))%DataPars.RealChannelsQuantity) strcat(stroka, "    ");
		else strcat(stroka, "\n");
		fputs(stroka, fptarget);
		if(!(i%100000L)) { if(kbhit()) { error=1; break; } printf(" Sample %ld from %ld\r", i, NPoints); }
	}

	fclose(fpsource);
	fclose(fpfilepars);
	fclose(fptarget);

	if(error) printf("\n\n	------- O-O-O-P-S!!!\n");
	else printf("\n\n	------- SUCCESS!!!\n");

	return 0;
}
