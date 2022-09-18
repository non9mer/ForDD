Подлежащий анализу текстовый файл необходимо разместить в корневой папке проекта. Выходной файл будет создан там же с именем .stats.txt.

Ответ на первое задание. Код запросов:
1)
  SELECT [NAME] from EMPLOYEE
  WHERE SALARY = (select max(SALARY) from EMPLOYEE)
  
2)
  SELECT [NAME] from [dbo].[EMPLOYEE] T1 JOIN [dbo].[DEPARTMENT] T2
  ON T2.ID = T1.ID
  WHERE SALARY = (select max(SALARY) from [dbo].[EMPLOYEE])
  
3)
  select TOP 1 [NAME] from [dbo].[EMPLOYEE] T1 JOIN [dbo].[DEPARTMENT] T2 
  ON T2.[ID]=T1.[ID] group by T2.[NAME] order by sum([SALARY]) desc
  
4)
  SELECT NAME from [dbo].[EMPLOYEE]
  where NAME like 'Р%н'
