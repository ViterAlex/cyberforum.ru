#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <fcntl.h>
#include <io.h>
#include <alloc.h>

//*****************************************************************
//
//*****************************************************************
int main(int n_p, char **str_p)
{
	int i;
	unsigned flash_word, n, m=12;
	unsigned char sourcefile[20];
	unsigned char targetfile[20];
	char stroka[17], *endptr;
	FILE *fps, *fpt;

	// если нет параметров, то выйдем
	if(n_p == 1)
	{
		puts("\n File Convertor from 'bio' format to 'dat'.\n\r"
				 " Copyright (c) 1999 L-Card Ltd.\n\r"
				 " Usage: bio_dat.exe  biofile[.bio]\n");
		exit(1);
	}

	// считаем название файла
	strcpy(sourcefile, str_p[n_p-1]);
	strcpy(targetfile, str_p[n_p-1]);
	if(!(endptr=strchr(sourcefile,'.'))) strcat(sourcefile, ".bio");
	else
	{
		strlwr(endptr);
		if(strcmp(endptr, ".bio"))
		{
			puts("\n File Convertor from 'bio' format to 'dat'.\n\r"
				 " Copyright (c) 1999 L-Card Ltd.\n\r"
				 " Usage: bio_dat.exe  biofile[.bio]\n");
			exit(1);
		}
	}

	if(!(endptr=strchr(targetfile,'.'))) strcat(targetfile, ".dat");
	else { *endptr=0; strcat(targetfile, ".dat"); }

	fps=fopen(sourcefile, "rb");
	if(fps == NULL) {	printf("\nНе могу открыть файл %s!\n", sourcefile); return 1; }

	fpt=fopen(targetfile, "wt");
	if(fpt == NULL) { printf("\nНе могу открыть файл %s!\n", targetfile); return 1; }

	fread(&n, 2, 1, fps);
	for(i=0; i < n; i++)
	{
		fread(&flash_word, 2, 1, fps);
		sprintf(stroka, "0x%02X", flash_word);
		if((i+1)%m) strcat(stroka, ", ");
		else strcat(stroka, ",\n");
		fputs(stroka, fpt);
	}

	fclose(fps);
	fclose(fpt);

	printf("\nСоздание файла %s успешно завершено!!!\n", targetfile);

	return 0;
}

