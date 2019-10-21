
create table ChucVu(
	chucVuID nvarchar(100) primary key,
	tenChucVu nvarchar(100),
	luongGio float
);

create table NguoiDung(
	taiKhoan nvarchar(100) primary key,
	matKhau nvarchar(100),
	hoTen nvarchar(100),
	noiO nvarchar(100),
	dienThoai varchar(100),
	gioiTinh nvarchar(100),
	chucVuID nvarchar(100) references ChucVu(chucVuID),
	danToc nvarchar(100),
	ngaySinh date,
	ngayBatDau date,
)
create table BangLuong(
	bangLuongID int primary key identity,
	taiKhoan nvarchar(100) references NguoiDung(taiKhoan),
	trangThai nvarchar(100),
	soGioDaLam int default 0,
	thang int,
	ngayNhanLuong datetime
)
create table NguyenLieu(
	nguyenLieuID nvarchar(100) primary key,
	tenNguyenLieu nvarchar(100),
	soLuong float,
	donVi nvarchar(100),
	gia float
)
create table TheBan(
	theBanID nvarchar(100) primary key
)
create table TheLoai(
	theLoaiID nvarchar(100) primary key,
	tenTheLoai nvarchar(100),
)
create table Mon(
	monID nvarchar(100) primary key,
	tenMon nvarchar(100),
	theLoaiID nvarchar(100) references TheLoai(theLoaiID),
	gia int,
	lanCapNhatGiaCuoiCung date,
	trangThai nvarchar(100)
)
create table chiTietMon(
	monID nvarchar(100) references Mon(monID),
	nguyenLieuID nvarchar(100) references NguyenLieu(nguyenLieuID),
	soLuong int,
	donVi nvarchar(100),
	primary key(monID, nguyenLieuID)
)
create table KhachHang(
	sdt float primary key,
	tenKhachHang nvarchar(100),
	tichDiem float
)

create table HoaDonKhachHang(
	hoaDonID int identity primary key,
	theBanID nvarchar(100) references TheBan(theBanID),
	taiKhoan nvarchar(100) references NguoiDung(taiKhoan),
	khachHangID float references KhachHang(sdt),	
	ngayTao date,
	ngayCapNhat date,
	giamGia int,
	tongTien float,
	trangThai nvarchar(100) default N'chưa thanh toán'
)

create table ChiTietHoaDon(
	hoaDonID int references HoaDonKhachHang(hoaDonID),
	monID nvarchar(100) references Mon(monID),
	gia int,
	soLuong int,
	primary key(hoaDonID, monID)
)


-- ============================================= STORE PROCEDURE =============================================


--1
drop procedure USP_DeleteNguoiDung

GO

CREATE PROCEDURE USP_DeleteNguoiDung 
 @taiKhoan nvarchar(100)
	
AS
BEGIN
	SET NOCOUNT ON;
	delete from NguoiDung
	where taiKhoan=@taiKhoan
END
GO
exec USP_DeleteNguoiDung N'qưe'



--2
drop procedure USP_UpdateNguoiDung
GO
CREATE PROCEDURE USP_UpdateNguoiDung 
	@taiKhoan nvarchar(100),
	@matKhau nvarchar(100),
	@hoTen nvarchar(100),
	@noiO nvarchar(100),
	@dienThoai varchar(100),
	@gioiTinh nvarchar(100),
	@chucVuID nvarchar(100),
	@danToc nvarchar(100),
	@ngaySinh date,
	@ngayBatDau date,
	@luongGioHT int
AS
BEGIN
	update NguoiDung
	set matKhau= @matKhau, hoTen= @hoTen, dienThoai= @dienThoai, gioiTinh= @gioiTinh, chucVuID= @chucVuID, danToc= @danToc, ngaySinh= @ngaySinh, ngayBatDau= @ngayBatDau,luongGioHT= @luongGioHT
	from NguoiDung
	where taiKhoan= @taiKhoan;
END
GO

exec USP_UpdateNguoiDung N'THANHTHAO',	N'123',	N'Nguyễn Thanh Thao',	N'249 Lã xuân Oai, T.3, KP.4, P.TNPA, Q.9',	'0981146193',	'Nữ',	'CV03',	'Kinh',	'1997-09-16',	'2018-01-01'
GO
-- 3


GO
CREATE PROCEDURE USP_getListNguoiDung 

AS
BEGIN
	select taiKhoan,hoTen,danToc,dienThoai,noiO,NguoiDung.chucVuID,gioiTinh,ngaySinh,ngayBatDau,matKhau,luongGioHT,tenChucVu
	from NguoiDung, ChucVu 
	where NguoiDung.chucVuID = ChucVu.chucVuID
	
END

GO
drop PROCEDURE USP_getListNguoiDung
go

exec USP_getListNguoiDung 

GO

-- 4
CREATE PROCEDURE USP_InsertNguoiDung 
	@taiKhoan nvarchar(100),
	@matKhau nvarchar(100),
	@hoTen nvarchar(100),
	@noiO nvarchar(100),
	@dienThoai varchar(100),
	@gioiTinh nvarchar(100),
	@chucVuID nvarchar(100),
	@danToc nvarchar(100),
	@ngaySinh date,
	@ngayBatDau date,
	@luongGioHT int
AS
BEGIN
	insert into NguoiDung (taiKhoan, matKhau, hoTen, noiO, dienThoai, gioiTinh, chucVuID, danToc, ngaySinh, ngayBatDau, luongGioHT)
	values(
		@taiKhoan, @matKhau, @hoTen, @noiO, @dienThoai, @gioiTinh, @chucVuID, @danToc, @ngaySinh, @ngayBatDau, @luongGioHT
	)
END
GO



--5
drop procedure USP_DeleteNguyenLieu

GO

CREATE PROCEDURE USP_DeleteNguyenLieu
 @nguyenLieuID nvarchar(100)
	
AS
BEGIN
	SET NOCOUNT ON;
	delete from NguyenLieu
	where nguyenLieuID=@nguyenLieuID
END
GO

--6
drop procedure USP_UpdateNguyenLieu
GO
CREATE PROCEDURE USP_UpdateNguyenLieu
	@nguyenLieuID nvarchar(100),
	@tenNguyenLieu nvarchar(100),
	@soLuong float,
	@donVi nvarchar(100),
	@gia float
AS
BEGIN
	update NguyenLieu
	set tenNguyenLieu= @nguyenLieuID, soLuong=@soLuong, donVi= @donVi, gia=@gia
	from NguyenLieu
	where nguyenLieuID= @nguyenLieuID;
END
GO


-- 7
CREATE PROCEDURE USP_getListNguyenLieu

AS
BEGIN
	select *
	from NguyenLieu
END

GO
drop PROCEDURE USP_getListNguyenLieu
go


-- 8
CREATE PROCEDURE USP_InsertNguyenLieu
	@nguyenLieuID nvarchar(100),
	@tenNguyenLieu nvarchar(100),
	@soLuong float,
	@donVi nvarchar(100),
	@gia float
AS
BEGIN
	insert into NguyenLieu (nguyenLieuID, tenNguyenLieu, soLuong, donVi, gia)
	values(
		@nguyenLieuID ,
		@tenNguyenLieu ,
		@soLuong,
		@donVi,
		@gia 
	)
END
GO
exec  USP_InsertNguyenLieu N'001', '123', '123', '123', '123'


--9

CREATE PROCEDURE USP_DeleteTheBan 
 @theBanID nvarchar(100)
	
AS
BEGIN
	SET NOCOUNT ON;
	delete from TheBan
	where theBanID=@theBanID
END
GO
exec USP_DeleteTheBan N'qưe'
GO


--10

CREATE PROCEDURE USP_UpdateTheBan
	@theBanIDOld nvarchar(100),	@theBanIDNew nvarchar(100)
AS
BEGIN
	update TheBan
	set theBanID=@theBanIDNew
	from TheBan
	where theBanID= @theBanIDOld;
END
GO

exec USP_UpdateTheBan N'001', N'qưe'
GO
drop PROCEDURE USP_UpdateTheBan
-- 11


GO
CREATE PROCEDURE USP_getListTheBan

AS
BEGIN
	select *
	from TheBan

END
go

exec USP_getListTheBan 

GO

-- 12
CREATE PROCEDURE USP_InsertTheBan
	@theBanID nvarchar(100)
AS
BEGIN
	insert into TheBan(theBanID)
	values(
		@theBanID
	)
END
GO

--13
CREATE PROCEDURE USP_getListTheLoai

AS
BEGIN
	select *
	from TheLoai
END

GO

--14
CREATE PROCEDURE USP_getListMon

AS
BEGIN
	select *
	from Mon

END
GO

--15
CREATE PROCEDURE USP_InsertMon
	@monID nvarchar(100),
	@tenMon nvarchar(100),
	@theLoaiID nvarchar(100),
	@gia int,
	@lanCapNhatCuoiCung nvarchar(100)
AS
BEGIN
	insert into Mon(monID, tenMon, theLoaiID, gia, lanCapNhatGiaCuoiCung )
	values(
		@monID,
		@tenMon,
		@theLoaiID,
		@gia,
		@lanCapNhatCuoiCung
	)
END
GO
drop PROCEDURE USP_InsertMon

--16
CREATE PROCEDURE USP_DeleteMon
 @monID nvarchar(100)
	
AS
BEGIN
	SET NOCOUNT ON;
	delete from Mon
	where monID=@monID
END
GO

--17 
CREATE PROCEDURE USP_UpdateMon
	@monIDOld nvarchar(100),
	@monIDNew nvarchar(100),
	@tenMon nvarchar(100),
	@theLoaiID nvarchar(100),
	@gia int,
	@lanCapNhatGiaCuoiCung date
AS
BEGIN
	update Mon
	set
	monID=@monIDNew,
	tenMon=@tenMon,
	theLoaiID=@theLoaiID,
	gia=@gia,
	lanCapNhatGiaCuoiCung=@lanCapNhatGiaCuoiCung
	from Mon
	where monID= @monIDOld
END
GO
drop PROCEDURE USP_UpdateMon

-- 18
CREATE PROCEDURE USP_getListChiTietMon 
	@monID nvarchar(100)
AS
BEGIN
	select NguyenLieu.nguyenLieuID,NguyenLieu.tenNguyenLieu,chiTietMon.soLuong, chiTietMon.donVi
	from Mon, NguyenLieu, chiTietMon
	where Mon.monID = @monID and chiTietMon.monID= @monID and chiTietMon.nguyenLieuID= NguyenLieu.nguyenLieuID   
END
GO
exec USP_getListChiTietMon N'M001'

drop PROCEDURE USP_getListChiTietMon
--19
CREATE PROCEDURE USP_InsertChiTietMon
	@monID nvarchar(100),
	@nguyenLieuID nvarchar(100),	
	@soLuong int,
	@donVi nvarchar(100)
AS
BEGIN
	insert into ChiTietMon(monID, nguyenLieuID, soLuong, donVi )
	values(
		@monID,
		@nguyenLieuID,
		@soLuong,
		@donVi
	)
END
GO

--20
CREATE PROCEDURE USP_DeleteChiTietMon
 @monID nvarchar(100),
@nguyenLieuID nvarchar(100)	
AS
BEGIN
	SET NOCOUNT ON;
	delete from chiTietMon
	where monID=@monID and nguyenLieuID= @nguyenLieuID
END
GO

--21 
CREATE PROCEDURE USP_UpdateChiTietMon
	@monID nvarchar(100),
@nguyenLieuID nvarchar(100)	,
@soLuong int
AS
BEGIN
	update chiTietMon
	set
	soLuong=@soLuong
	from chiTietMon
	where monID=@monID and nguyenLieuID= @nguyenLieuID
END
GO

-- 22
Create PROCEDURE USP_getListFromTheLoai
	@tenTheLoai nvarchar(100)
AS
BEGIN
	select * from Mon, TheLoai
	where Mon.theLoaiID=TheLoai.theLoaiID and tenTheLoai= @tenTheLoai
END
go

-- 23
CREATE PROCEDURE USP_InsertHoaDonKhachHang
@theBanID nvarchar(100)
AS
BEGIN
	insert into HoaDonKhachHang(theBanID) values( @theBanID)
END 
go
drop PROCEDURE USP_InsertHoaDonKhachHang
go
-- 24
CREATE PROCEDURE USP_GetRowFromTheIDInHoaDonKhachHang @theBanID nvarchar(100)
as
begin
	select* from HoaDonKhachHang where theBanID= @theBanID and trangThai=N'chưa thanh toán'
end
go
-- 25 
CREATE PROCEDURE USP_GetListChiTietHoaDonFromHoaDon @hoaDonID int
as 
begin
	select* 
	from ChiTietHoaDon, Mon
	where hoaDonID=@hoaDonID and Mon.monID= ChiTietHoaDon.monID
end
go
drop PROCEDURE USP_GetListChiTietHoaDonFromHoaDon
go

-- 26
CREATE PROCEDURE USP_InsertChiTietHoaDon @hoaDonID int, @monID nvarchar(100), @theBanID nvarchar(100)
as
begin
	insert into ChiTietHoaDon(hoaDonID, monID, theBanID)
	values (@hoaDonID, @monID, @theBanID)
end
go
drop PROCEDURE USP_InsertChiTietHoaDon
go

-- 27
CREATE PROCEDURE USP_UpdateGiaSoLuongChiTietHoaDon @hoaDonID int, @monID nvarchar(100)
as
begin
	update ChiTietHoaDon 
	set gia= ChiTietHoaDon.gia + Mon.gia, soLuong= ChiTietHoaDon.soLuong+1
	from ChiTietHoaDon, Mon
	where ChiTietHoaDon.hoaDonID= @hoaDonID and ChiTietHoaDon.monID= @monID and Mon.monID=@monID
end  
go
-- 29
CREATE PROCEDURE USP_AcceptGiaSoLuongChiTietHoaDon @hoaDonID int, @monID nvarchar(100)
as
begin
	update ChiTietHoaDon 
	set gia= ChiTietHoaDon.gia - Mon.gia, soLuong= ChiTietHoaDon.soLuong-1
	from ChiTietHoaDon, Mon
	where ChiTietHoaDon.hoaDonID= @hoaDonID and ChiTietHoaDon.monID= @monID and Mon.monID=@monID
end  
go

-- 30
CREATE PROCEDURE USP_UpdateGiamGiaToHoaDonKhachHang @hoaDonID int, @giamGia int
as
begin
	update HoaDonKhachHang
	set giamGia=@giamGia
	where hoaDonID=@hoaDonID

end
go

-- 31
CREATE PROCEDURE USP_UpdatePhiPhuThuToHoaDonKhachHang @hoaDonID int, @phiPhuThu float
as
begin
	update HoaDonKhachHang
	set phiPhuThu=@phiPhuThu
	where hoaDonID=@hoaDonID

end

-- 32
CREATE PROCEDURE USP_GetHoaDonKhachHangTam
as
begin
	select*from HoaDonKhachHangTam
end

--33
CREATE PROCEDURE USP_GetRowHoaDonKhachHangFromHoaDonID @hoaDonID int
as
begin
	select *from HoaDonKhachHang where hoaDonID= @hoaDonID
end

go
exec USP_GetRowHoaDonKhachHangFromHoaDonID 16
go

-- 34 
CREATE PROCEDURE USP_UpdateHoaDonKhachHang @hoaDonID int,@theBanID nvarchar(100), @taiKhoan nvarchar(100), @khachHangID float, @ngayTao date, @ngayCapNhat date, @tongTien float
as
begin
	update HoaDonKhachHang
	set theBanID=@theBanID,
		taiKhoan=@taiKhoan,
		khachHangID=@khachHangID,
		ngayTao=@ngayTao,
		ngayCapNhat=@ngayCapNhat,
		tongTien=@tongTien,
		trangThai=N'Đã thanh toán'
	where hoaDonID=@hoaDonID
end
go
drop PROCEDURE USP_UpdateHoaDonKhachHang
go

-- 35
CREATE PROCEDURE USP_GetNguoiDungFromID @taiKhoan nvarchar(100)
as
begin
	select*from NguoiDung where taiKhoan= @taiKhoan
end
--================================= TRIGGER ===================================
--1
CREATE TRIGGER UTG_InsertedChiTietHoaDon on ChiTietHoaDon
for insert 
as
declare @theBanID nvarchar(100)
declare @monID nvarchar(100)
declare @hoaDonID int

Select @theBanID= ins.theBanID from inserted ins
Select @monID= ins.monID from inserted ins
Select @hoaDonID= ins.hoaDonID from inserted ins

	update TheBan
	set trangThai=N'có người'
	from TheBan
	where theBanID= @theBanID

	update ChiTietHoaDon
	set gia= Mon.gia, soLuong=1
	from ChiTietHoaDon, Mon
	where ChiTietHoaDon.hoaDonID=@hoaDonID and ChiTietHoaDon.monID= @monID and Mon.monID= @monID

	update HoaDonKhachHang
		set tongTien= s.gia from(
					select  sum(gia) as gia
					from HoaDonKhachHang, ChiTietHoaDon
					where HoaDonKhachHang.hoaDonID= @hoaDonID) as s, HoaDonKhachHang, ChiTietHoaDon
					where HoaDonKhachHang.hoaDonID= @hoaDonID

go
drop TRIGGER UTG_InsertedChiTietHoaDon

--2
CREATE TRIGGER UTG_UpdatedChiTietHoaDon on ChiTietHoaDon
for Update 
as
declare @monID nvarchar(100)
declare @hoaDonID int

Select @monID= ins.monID from inserted ins
Select @hoaDonID= ins.hoaDonID from inserted ins

if(exists(select * from ChiTietHoaDon where hoaDonID= @hoaDonID and monID= @monID and soLuong=0))
begin
	delete from ChiTietHoaDon
	where hoaDonID=@hoaDonID and monID=@monID
end
if(exists(select * from ChiTietHoaDon where hoaDonID= @hoaDonID and monID= @monID ))
begin
update HoaDonKhachHang
		set tongTien= s.gia from(
					select  sum(gia) as gia
					from HoaDonKhachHang, ChiTietHoaDon
					where HoaDonKhachHang.hoaDonID= @hoaDonID) as s, HoaDonKhachHang, ChiTietHoaDon
					where HoaDonKhachHang.hoaDonID= @hoaDonID
end
go
drop TRIGGER UTG_UpdatedChiTietHoaDon

go

--3
CREATE TRIGGER UTG_DeleteChiTietHoaDon on ChiTietHoaDon
for delete
as

declare @theBanID nvarchar(100)
declare @monID nvarchar(100)
declare @hoaDonID int

Select @theBanID= ins.theBanID from deleted ins
Select @monID= ins.monID from deleted ins
Select @hoaDonID= ins.hoaDonID from deleted ins

if(not exists(select* from ChiTietHoaDon where hoaDonID=@hoaDonID))
begin
	update TheBan
	set trangThai=N'không'
	from TheBan
	where theBanID= @theBanID

	update HoaDonKhachHang
	set tongTien= s.gia from(
				select  sum(gia) as gia
				from HoaDonKhachHang, ChiTietHoaDon
				where HoaDonKhachHang.hoaDonID= @hoaDonID) as s,
	HoaDonKhachHang, ChiTietHoaDon
				where HoaDonKhachHang.hoaDonID= @hoaDonID
end
go
drop TRIGGER UTG_DeleteChiTietHoaDon
go

-- 4
CREATE TRIGGER UTG_UpdateHoaDonKhachHang on HoaDonKhachHang
for update
as
declare @hoaDonID int
declare @theBanID nvarchar(100)
declare @taiKhoan nvarchar(100)
declare @khachHangID float
declare @tongTien float
declare @trangThai nvarchar(100)

select @hoaDonID=ins.hoaDonID from inserted ins
select @theBanID=ins.theBanID from inserted ins
select @taiKhoan=ins.taiKhoan from inserted ins
select @khachHangID=ins.khachHangID from inserted ins
select @tongTien=ins.tongTien from inserted ins
select @trangThai=ins.trangThai from inserted ins

if(@trangThai=N'Đã thanh toán')
begin
	update TheBan
	set trangThai=N'không'
	where theBanID= @theBanID
	if(exists(select*from KhachHang where sdt=@khachHangID))
	begin
		update KhachHang
		set tichDiem= tichDiem+@tongTien
		where sdt=@khachHangID
	end
	else
	begin
		insert into KhachHang(sdt, tichDiem)
		values(@khachHangID, @tongTien)
	end
end





--================================== FUNCTION ======================================

-- 1
CREATE FUNCTION UF_KiemTraTaiKhoanDaCo(@taiKhoan nvarchar(100))
RETURNS bit
AS
BEGIN
	declare @count int
	set @count=0
	select @count= COUNT(taiKhoan)
	from NguoiDung
	where taiKhoan=@taiKhoan
	if(@count=0)
		begin
			return 0
		end 
	RETURN 1
END
GO
select dbo.UF_KiemTraTaiKhoanDaCo ('NGUYENHIE') as counts
GO
drop FUNCTION UF_KiemTraTaiKhoanDaCo

-- 2
CREATE FUNCTION UF_KiemTraIDNguyenLieuDaCo (@nguyenLieuID nvarchar(100))
RETURNS bit
AS
BEGIN
	declare @count int
	set @count=0
	select @count= COUNT(nguyenLieuID)
	from NguyenLieu
	where nguyenLieuID=@nguyenLieuID
	if(@count=0)
		begin
			return 0
		end 
	RETURN 1
END
GO
select dbo.UF_KiemTraIDNguyenLieuDaCo (N'001')
GO

-- 3
CREATE FUNCTION UF_KiemTraIDTheDaCo (@theID nvarchar(100))
RETURNS bit
AS
BEGIN
	declare @count int
	set @count=0
	select @count= COUNT(theBanID)
	from TheBan
	where theBanID=@theID
	if(@count=0)
		begin
			return 0
		end 
	RETURN 1
END
GO
select dbo.UF_KiemTraIDTheDaCo (N'001')
GO
drop FUNCTION UF_KiemTraIDTheDaCo
go

-- 4
Create FUNCTION UF_LayDonViTuNguyenLieu (@nguyenLieuID nvarchar(100))
RETURNS nvarchar(100)
AS
begin
	declare @donVi nvarchar(100)
	select @donVi= donVi
	from NguyenLieu
	where nguyenLieuID=@nguyenLieuID
	return @donVi
end
select dbo.UF_LayDonViTuNguyenLieu ('NL001')
go

--5 
Create FUNCTION UF_CheckLikeChiTietMon (@monID nvarchar(100), @nguyenLieuID nvarchar(100))
RETURNS int
AS
begin
	if(exists(select*from chiTietMon where monID= @monID and nguyenLieuID=@nguyenLieuID))
		begin 
		return 1
		end
	return 0
end
go
select dbo.UF_CheckLikeChiTietMon (N'M002', N'NL001')
go
-- 6
CREATE FUNCTION UF_CheckTheTheoHoaDonForInsertHoaDonKhachHang (@theBanID nvarchar(100))
returns int
AS 
begin
	if exists(select * from HoaDonKhachHang where theBanID= @theBanID and trangThai=N'chưa thanh toán')
	begin
		return 1
	end

	return 0
end 
go
drop function UF_CheckTheTheoHoaDonForInsertHoaDonKhachHang
go
select dbo.UF_CheckTheTheoHoaDonForInsertHoaDonKhachHang(N'N') as s

-- 7
CREATE FUNCTION UF_CheckChiTietHoaDonHad (@hoaDonID int, @monID nvarchar(100), @theBan nvarchar(100))
returns int
as
begin
	if(exists(select*from ChiTietHoaDon where hoaDonID= @hoaDonID and monID= @monID))
	begin		
		return 1
	end	
	return 0
end
go
drop FUNCTION UF_CheckChiTietHoaDonHad
go
select dbo.UF_CheckChiTietHoaDonHad (1,N'M001',N'B1')
go

-- 8
CREATE FUNCTION UF_CheckLogin (@taiKhoan nvarchar(100), @matKhau nvarchar(100))
returns int
as
begin
	if(exists(select*from NguoiDung where taiKhoan=@taiKhoan and matKhau=@matKhau))
	begin
		return 1
	end
	return 0
end
go
--9
CREATE FUNCTION UF_CheckSDTKhachHang (@SDT float)
returns int
as
begin
	if(exists(select*from KhachHang where sdt=@SDT))
	begin
		return 1
	end
	return 0
end
go

-- 10
CREATE FUNCTION UF_GetTichLuy (@SDT float)
returns float

as
begin
	declare @tichLuy float
	select @tichLuy= s.tichDiem
	from(
	select *
	from KhachHang
	where sdt=@SDT)as s
	return @tichLuy
end

--11

