﻿/*----------------------------------------------------------
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN
LAB: 03
NGAY: 05/04/2023
----------------------------------------------------------*/
USE MASTER
GO

IF DB_ID('QLSinhVien') IS NOT NULL
	DROP DATABASE QLSinhVien
GO

CREATE DATABASE QLSinhVien
GO