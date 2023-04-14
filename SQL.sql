--DELETE SP
--drop procedure SPCONSULTAMIXDESPACHOS
go

SELECT * FROM MIXDESPACHOS

CREATE PROCEDURE SPCONSULTAMIXDESPACHOS
@_COD_PRO NVARCHAR (10)
--@_COD_VAR NVARCHAR (4)
AS

--select LOTE AS [LOTE SIN FILTRO], COD_PRO as PRODUCTOR, CAJAS, SEMANA_COSECHA, COD_VAR
--from MIXDESPACHOS
--where COD_TEM='11' 
--and COD_EMP='CER'
--and COD_ESP <> 'CIE'
--ORDER BY PRODUCTOR,[LOTE SIN FILTRO] ASC


select LOTE AS [LOTE MIXD]
			,COD_PRO as PRODUCTOR
			,CAJAS
			,isnull(SEMANA_COSECHA,'no') AS SEMANA
			,COD_VAR AS VARIEDAD
			,COD_ETI AS ETIQUETA
			,COD_ENVOP AS [ENVASE OP]
			,FECHA_COSECHA AS FECHA
			,CORRELATIVO
from MIXDESPACHOS
where COD_TEM='11' 
and COD_EMP='CER' 
and COD_ESP <> 'CIE'
--and COD_VAR= --'LP' 
--and SEMANA_COSECHA='49'
and COD_PRO= @_COD_PRO					--'99074' 
ORDER BY CAJAS ASC

 
--select  LOTE AS [LOTE PRELIQ], COD_PRO as PRODUCTOR, CAJAS 
--from PRECIOLIQ_DET 
--where COD_TEM='11' 
--and COD_EMP='CER' 
--and COD_ESP <> 'CIE'
--and COD_PRO= @_COD_PRO 
----and COD_VAR='LP'
--ORDER BY [LOTE PRELIQ] ASC
--go
--

EXEC SPCONSULTAMIXDESPACHOS @_COD_PRO='87474'
GO


--drop procedure SPCONSULTAPRECIOLIQ

CREATE PROCEDURE SPCONSULTAPRECIOLIQ
@_COD_PRO NVARCHAR (10)
--@_COD_VAR NVARCHAR (4)
AS
select  LOTE AS [LOTE PRELIQ]
		,COD_PRO as PRODUCTOR
		,CAJAS
		,COD_VAR AS VARIEDAD
		,COD_ETI AS ETIQUETA
		,COD_ENVOP as [ENVASE OP]
		,ID_PRECIOLIQ_DET as [CORRELATIVO PRECIOLIQ]
from PRECIOLIQ_DET 
where COD_TEM='11' 
and COD_EMP='CER' 
and COD_ESP <> 'CIE'
and COD_PRO= @_COD_PRO 
--and COD_VAR='LP'
ORDER BY CAJAS ASC
go


EXEC SPCONSULTAPRECIOLIQ @_COD_PRO='99074'

select LOTE AS [LOTE PRELIQ]
		,COD_PRO as PRODUCTOR
		,CAJAS
		,COD_VAR AS VARIEDAD
		,COD_ETI AS ETIQUETA
		,COD_ENVOP as [ENVASE OP]
		,ID_PRECIOLIQ_DET as [CORRELATIVO PRECIOLIQ]
from PRECIOLIQ_DET 
where COD_TEM='11' 
and COD_EMP='CER' 
and COD_ESP <> 'CIE'







-- hacemos update A MIX DESPACHO
--drop procedure SPCUADRATURAMIXD

CREATE PROCEDURE SPCUADRATURAMIXD
@_LOTE NVARCHAR(10),
@_DONDE_COD_PRO NVARCHAR(10),
@_SETEAR_COD_PRO NVARCHAR(10),
@_COD_VAR NVARCHAR(3),
@_SEMANA NVARCHAR(2),
@_CORRELATIVO INT,
@_CAJAS INT
AS

UPDATE MXD SET MXD.COD_PRO=@_SETEAR_COD_PRO	--'99074' --105924
from MIXDESPACHOS MXD
where COD_TEM='11' 
and COD_EMP='CER'
AND LOTE= @_LOTE
AND COD_PRO = @_DONDE_COD_PRO				--='105924'
AND COD_VAR= @_COD_VAR						--'LP'
AND SEMANA_COSECHA= @_SEMANA	--'49'
AND CORRELATIVO=@_CORRELATIVO
AND CAJAS=@_CAJAS

			----- el primer update
			--			--UPDATE PLIQ SET PLIQ.COD_PRO=@_SETEAR_COD_PRO
			--			--from PRECIOLIQ_DET PLIQ 
			--			--where COD_TEM='11' 
			--			--and COD_EMP='CER' 
			--			--and COD_PRO= @_DONDE_COD_PRO 
			--			--AND LOTE=@_LOTE
			-----------------


EXEC SPCUADRATURAMIXD @_LOTE='5530088135',@_DONDE_COD_PRO='87474'
					 ,@_SETEAR_COD_PRO='106683'		
					 ,@_COD_VAR='IV'
					 ,@_SEMANA='45'
					 ,@_CAJAS='1'
					 ,@_CORRELATIVO='1294558368'
GO








--- HACMEOS UPDATE A PRECIOLIQ
--drop procedure SPCUADRATURAPRECIOLIQ

CREATE PROCEDURE SPCUADRATURAPRECIOLIQ
@_LOTE NVARCHAR(10),
@_DONDE_COD_PRO NVARCHAR(10),
@_SETEAR_COD_PRO NVARCHAR(10),
@_COD_VAR NVARCHAR(3),
@_CAJAS INT,
@_IDPRECIOLIQ INT
--@_CORRELATIVO_MIXD INT,
--@_SEMANA INT
AS

--SELECT * FROM PRECIOLIQ_DET where COD_TEM='11' 
--and COD_ESP <> 'CIE'
--and COD_EMP='CER' 
--and COD_PRO='87474'
--AND LOTE='5530110071'
--and CAJAS='65'
--and COD_VAR='BI'
--and ID_PRECIOLIQ_DET='410358'

		
UPDATE PLIQ SET PLIQ.COD_PRO=@_SETEAR_COD_PRO		--'87474'	--@_SETEAR_COD_PRO
from PRECIOLIQ_DET PLIQ 
where COD_TEM='11' 
and COD_ESP <> 'CIE'										--and COD_ESP <> 'CIE'
and COD_EMP='CER'											--and COD_EMP='CER' 
and COD_PRO=@_DONDE_COD_PRO											--and COD_PRO=@_DONDE_COD_PRO			-- @_DONDE_COD_PRO 
AND LOTE=@_LOTE										--and COD_PRO=@_DONDE_COD_PRO			-- @_DONDE_COD_PRO 
and CAJAS=@_CAJAS												--and COD_PRO=@_DONDE_COD_PRO			-- @_DONDE_COD_PRO 
and COD_VAR=@_COD_VAR											--AND LOTE=@_LOTE
and ID_PRECIOLIQ_DET=@_IDPRECIOLIQ								--and CAJAS=@_CAJAS
				--AND exists(select CAJAS		
				--			from MIXDESPACHOS
				--			where COD_TEM='11' 
				--			and COD_EMP='CER' 
				--			and COD_ESP <> 'CIE'
				--			AND LOTE= @_LOTE
				--			AND COD_PRO = @_DONDE_COD_PRO				--='105924'
				--			AND COD_VAR= @_COD_VAR						--'LP'
				--			AND SEMANA_COSECHA= @_SEMANA	--'49'
				--			AND CORRELATIVO=@_CORRELATIVO_MIXD
				--			AND CAJAS=@_CAJAS
				--		   )
GO
--


EXEC SPCUADRATURAPRECIOLIQ @_LOTE='5530088135',@_DONDE_COD_PRO='87474',@_SETEAR_COD_PRO='106683',@_COD_VAR='IV',@_CAJAS='1',@_IDPRECIOLIQ='479331'

SELECT LOTE,COD_PRO,COD_VAR,CAJAS,ID_PRECIOLIQ_DET FROM PRECIOLIQ_DET where COD_TEM='11' 
and COD_ESP <> 'CIE'
and COD_EMP='CER' 
and COD_PRO='87474'
AND LOTE='5530111595'
and CAJAS='1'
and COD_VAR='LP'
and ID_PRECIOLIQ_DET='510092'












-----------------PRUEBA PARA COMPARAR
EXEC SPCONSULTAMIXDESPACHOS @_COD_PRO='87474'
GO


select DISTINCT M.LOTE
			,M.COD_PRO
			,M.CAJAS AS CAJAS_D
			,sum(M.CAJAS) OVER (partition by M.COD_PRO order by M.COD_PRO) as [SUM_CAJAS_D]
			,P.CAJAS AS CAJAS_P
			,M.COD_VAR
			,M.COD_ETI 
			,M.COD_ENVOP
			,M.FECHA_COSECHA
			,M.CORRELATIVO

FROM MIXDESPACHOS M INNER JOIN PRECIOLIQ_DET P ON M.LOTE = P.LOTE
--INNER JOIN PRECIOLIQ_DET PP ON M.CAJAS = PP.CAJAS

where M.COD_TEM='11' 
and M.COD_EMP='CER' 
and M.COD_ESP <> 'CIE'
--and COD_VAR= --'LP' 
--and SEMANA_COSECHA='49'
and M.COD_PRO= '87474'					--'99074'
and M.LOTE='5530085091'
GROUP BY M.LOTE
		,M.COD_PRO
		,M.CAJAS
		,P.CAJAS
		,M.COD_VAR
		,M.COD_ETI
		,M.COD_ENVOP 
		,M.FECHA_COSECHA
		,M.CORRELATIVO
ORDER BY M.LOTE
		,M.COD_PRO
		,M.CAJAS
		,P.CAJAS
		,M.COD_VAR
		,M.COD_ETI
		,M.COD_ENVOP 
		,M.FECHA_COSECHA
		,M.CORRELATIVO
GO








--- COMPARACION DE REGISTROS



--intersect
--except




SELECT LOTE,CAJAS FROM MIXDESPACHOS where COD_TEM='11' 
and COD_EMP='CER' 
and COD_ESP <> 'CIE'
--and COD_VAR= --'LP' 
--and SEMANA_COSECHA='49'
and COD_PRO= '87474'					--'99074'
and LOTE='5530085091'

--UNION ALL
SELECT LOTE,CAJAS FROM PRECIOLIQ_DET where COD_TEM='11' 
and COD_EMP='CER' 
and COD_ESP <> 'CIE'
--and COD_VAR= --'LP' 
--and SEMANA_COSECHA='49'
and COD_PRO= '87474'					--'99074'
and LOTE='5530085091'
GO







		
																				--		(SELECT P.CAJAS FROM PRECIOLIQ_DET P
																				--									where P.COD_TEM='11' 
																				--									and P.COD_EMP='CER' 
																				--									and P.COD_ESP <> 'CIE'
																				--									--and COD_VAR= --'LP' 
																				--									--and SEMANA_COSECHA='49'
																				--									and P.COD_PRO=@_PRODUCTOR	--'87474'					--'99074'
																				--									and P.LOTE=@_LOTE--'5530085091'
																				----							 )

																				--				--intersect
																				--				except

																				----		SELECT @VAR_PREC_ = (
																				--		select DISTINCT	M.CAJAS-- OVER (partition by M.COD_PRO) as [SUM_CAJAS_D]
																				--									FROM MIXDESPACHOS M  --INNER JOIN  PRECIOLIQ_DET P ON M.CAJAS = P.CAJAS
																				--									where M.COD_TEM='11' 
																				--									and M.COD_EMP='CER' 
																				--									and M.COD_ESP <> 'CIE'
																				--									--and COD_VAR= --'LP' 
																				--									--and SEMANA_COSECHA='49'
																				--									and M.COD_PRO=@_PRODUCTOR	--'87474'					--'99074'
																				--									and M.LOTE=@_LOTE	--'5530085091'
																				----							)}


--DROP PROCEDURE SPCOMPARARTEST

CREATE PROCEDURE SPCOMPARARTEST
@_PRODUCTOR NVARCHAR(12),
@_LOTE NVARCHAR(12)
--@SALIDACOMPARACION_ INT OUTPUT
AS
		--DECLARE	@VAR_MIXD_ INT
--		DECLARE	@VAR_PREC_ INT


--		SELECT @VAR_MIXD_ = (
--IF (


--(
select DISTINCT	M.CAJAS-- OVER (partition by M.COD_PRO) as [SUM_CAJAS_D]
									FROM MIXDESPACHOS M  --INNER JOIN  PRECIOLIQ_DET P ON M.CAJAS = P.CAJAS
									where M.COD_TEM='11' 
									and M.COD_EMP='CER' 
									and M.COD_ESP <> 'CIE'
									--and COD_VAR= --'LP' 
									--and SEMANA_COSECHA='49'
									and M.COD_PRO=@_PRODUCTOR		--'106683'					--'99074'
									and M.LOTE=@_LOTE		--'5530088135'
							--)

							intersect
							--	except


--(
		SELECT P.CAJAS FROM PRECIOLIQ_DET P
											where P.COD_TEM='11' 
											and P.COD_EMP='CER' 
											and P.COD_ESP <> 'CIE'
											--and COD_VAR= --'LP' 
											--and SEMANA_COSECHA='49'
											and P.COD_PRO=@_PRODUCTOR		--'106683'					--'99074'
											and P.LOTE=@_LOTE		--'5530088135'
--							 )


--	) > 0)


--PRINT 0
--ELSE
--PRINT 1
--SET @TOTAL_ =		@VAR_MIXD_
--					INTERSECT
--					@VAR_PREC_


EXEC SPCOMPARARTEST @_PRODUCTOR='106683',@_LOTE='5530088135'			--'5530082200'			--'5530086730'





		select DISTINCT	M.CAJAS-- OVER (partition by M.COD_PRO) as [SUM_CAJAS_D]
									FROM MIXDESPACHOS M  --INNER JOIN  PRECIOLIQ_DET P ON M.CAJAS = P.CAJAS
									where M.COD_TEM='11' 
									and M.COD_EMP='CER' 
									and M.COD_ESP <> 'CIE'
									--and COD_VAR= --'LP' 
									--and SEMANA_COSECHA='49'
									and M.COD_PRO='106683'					--'99074'
									and M.LOTE='5530088135'
							--)

							intersect
							--	except


--(
		SELECT P.CAJAS FROM PRECIOLIQ_DET P
											where P.COD_TEM='11' 
											and P.COD_EMP='CER' 
											and P.COD_ESP <> 'CIE'
											--and COD_VAR= --'LP' 
											--and SEMANA_COSECHA='49'
											and P.COD_PRO='106683'					--'99074'
											and P.LOTE='5530088135'
--							 )

			--intersect
			--	except

--		SELECT @VAR_PREC_ = (
		select DISTINCT	M.CAJAS-- OVER (partition by M.COD_PRO) as [SUM_CAJAS_D]
									FROM MIXDESPACHOS M  --INNER JOIN  PRECIOLIQ_DET P ON M.CAJAS = P.CAJAS
									where M.COD_TEM='11' 
									and M.COD_EMP='CER' 
									and M.COD_ESP <> 'CIE'
									--and COD_VAR= --'LP' 
									--and SEMANA_COSECHA='49'
									and M.COD_PRO='106683'					--'99074'
									and M.LOTE='5530088135'
							--)





--------------CALCULAR ---------|||
--DROP PROCEDURE SPCALCULARCAJAS



---|||mostrar envases
CREATE PROCEDURE SPENVASE
--@_COD_ENVOP NVARCHAR(15)
AS
SELECT TOP (1000) [COD_TEM]
      ,[COD_EMP]
      ,[COD_ESP]
      ,[COD_ENVOP]
      ,[DESCRIPCION]
      ,[PESO_NETO]
      ,[PESO_BRUTO]
      ,[CAJAS_ENVOP]
  FROM [erpfrusys].[dbo].[ENVASEOPERACIONAL]
  where COD_TEM='11'
  AND COD_EMP='CER'
  --AND COD_ENVOP=		--@_COD_ENVOP
  GO

  EXEC SPENVASE



CREATE PROCEDURE SPCALCULARCAJAS
@_COD_ENVOP NVARCHAR(15)
AS
SELECT TOP (1000) [COD_TEM]
      ,[COD_EMP]
      ,[COD_ESP]
      ,[COD_ENVOP]
      ,[DESCRIPCION]
      ,[PESO_NETO]
      ,[PESO_BRUTO]
      ,[CAJAS_ENVOP]
  FROM [erpfrusys].[dbo].[ENVASEOPERACIONAL]
  where COD_TEM='11'
  AND COD_EMP='CER'
  --and COD_ESP=''
  AND COD_ENVOP=@_COD_ENVOP --'CE5BGVMC' 
  GO

  EXEC SPCALCULARCAJAS @_COD_ENVOP='CE5GSRM'