create database quanlyphongtro;
use quanlyphongtro;

-- Chủ trọ
create table chutro (
    id_chutro int primary key,
    hoten nvarchar(50),
    sdt varchar(10),
    email varchar(100),
    diachi nvarchar(255),
    taikhoan varchar(50),
    matkhau varchar(15)
);

-- Phòng trọ
create table phongtro (
    id_phong int primary key,
	id_chutro int,
    tenphong nvarchar(10),
    giaphong decimal(12,2),
    tinhtrang nvarchar(50),
    foreign key (id_chutro) references chutro(id_chutro)
);

-- Người thuê
create table nguoithue (
    id_nguoithue int primary key,
	id_phong int,
    hoten nvarchar(50),
    cccd varchar(12),
    sdt varchar(10),
    email varchar(100),
	taikhoan varchar(50),
    matkhau varchar(15),
	foreign key (id_phong) references phongtro(id_phong)
);

-- Hợp đồng
create table hopdong (
    id_hopdong int primary key,
    id_phong int,
    id_chutro int,
    id_nguoithue int,
    ngaybatdau date,
    ngayketthuc date,
    tiencoc decimal(12,2),
    foreign key (id_chutro) references chutro(id_chutro),
    foreign key (id_phong) references phongtro(id_phong),
    foreign key (id_nguoithue) references nguoithue(id_nguoithue)
);

-- Tiền lệ phí (tiền phòng + dịch vụ)
create table lephi (
    id_lephi int primary key,
    ngaytao date,
    tienphong decimal(12,2),
    tiendv decimal(12,2),
    thanhtien_lephi decimal(12,2)
);

-- Tiền điện
create table dien (
    id_dien int primary key,
    ngaytao date,
    chiso_dau decimal(12,2),
    chiso_cuoi decimal(12,2),
    thanhtien_dien decimal(12,2)
);

-- Tiền nước
create table nuoc (
    id_nuoc int primary key,
    ngaytao date,
    chiso_dau decimal(12,2),
    chiso_cuoi decimal(12,2),
    thanhtien_nuoc decimal(12,2)
);

--Mối quan hệ giữa nguoithue và chitiethoadon 
create table thanhtoan(
	id_hoadon int,
	id_nguoithue int,
	primary key(id_hoadon, id_nguoithue),
	ngaythanhtoan date,
	foreign key (id_hoadon) references hoadon(id_hoadon),
	foreign key (id_nguoithue) references nguoithue(id_nguoithue)
);

-- Hóa đơn
create table hoadon (
    id_hoadon int primary key,
    ngaytao date,
    trangthai nvarchar(50),
	noidung nvarchar(50),
    id_lephi int,
    id_dien int,
    id_nuoc int,
	id_phong int,
    thanhtien decimal(12,2),
	foreign key (id_phong) references phongtro(id_phong),
    foreign key (id_lephi) references lephi(id_lephi),
    foreign key (id_dien) references dien(id_dien),
    foreign key (id_nuoc) references nuoc(id_nuoc)
);
