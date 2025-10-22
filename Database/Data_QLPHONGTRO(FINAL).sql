create database DB_QLPHONGTRO
use DB_QLPHONGTRO

-- Tạo bảng lephi (Lệ phí/Phí dịch vụ)
CREATE TABLE lephi (
    id_lephi VARCHAR(50) PRIMARY KEY,
    tenphong VARCHAR(100) NOT NULL,
    tien_dv DECIMAL(18, 2) NOT NULL,
    thanh_tien_lephi DECIMAL(18, 2) NOT NULL
);

---
-- Tạo bảng chutro (Chủ trọ)
CREATE TABLE chutro (
    id_chutro VARCHAR(50) PRIMARY KEY,
	hoten NVARCHAR(50),
    sdt VARCHAR(15),
    email VARCHAR(100) ,
    diachi VARCHAR(255),
    taikhoan VARCHAR(100),
    matkhau VARCHAR(255) NOT NULL,
    avatar_url TEXT,
    anh_cccd_truoc_url TEXT,
    anh_cccd_sau_url TEXT
);

---
-- Tạo bảng phongtro (Phòng trọ)
CREATE TABLE phongtro (
    id_phong VARCHAR(50) PRIMARY KEY,
    id_chutro VARCHAR(50) NOT NULL,
    tenphong VARCHAR(100) NOT NULL,
    giaphong DECIMAL(18, 2) NOT NULL,
    sinhtrang VARCHAR(50),
    -- ĐÃ SỬA LỖI 1785: Dùng ON DELETE NO ACTION để phá vỡ chu kỳ xóa tiềm năng
    FOREIGN KEY (id_chutro) REFERENCES chutro(id_chutro) ON DELETE NO ACTION
);

---
-- Tạo bảng nguoi_thue (Người thuê)
CREATE TABLE nguoi_thue (
    id_nguoi_thue VARCHAR(50) PRIMARY KEY,
    id_phong VARCHAR(50) NOT NULL,
    hoten VARCHAR(100) NOT NULL,
    cccd VARCHAR(20) UNIQUE,
    sdt VARCHAR(15) UNIQUE,
    email VARCHAR(100) UNIQUE,
    -- Ngăn xóa phòng trọ nếu đang có người thuê.
    FOREIGN KEY (id_phong) REFERENCES phongtro(id_phong) ON DELETE NO ACTION
);

---
-- Tạo bảng hopdong (Hợp đồng)
CREATE TABLE hopdong (
    id_hopdong VARCHAR(50) PRIMARY KEY,
    id_phong VARCHAR(50) NOT NULL,
    id_chutro VARCHAR(50) NOT NULL,
    id_nguoi_thue VARCHAR(50) NOT NULL,
    ngay_bat_dau DATE NOT NULL,
    ngay_ket_thuc DATE,
    tien_coc DECIMAL(18, 2) NOT NULL,
    -- Ngăn xóa phòng, chủ trọ, người thuê nếu còn hợp đồng.
    FOREIGN KEY (id_phong) REFERENCES phongtro(id_phong) ON DELETE NO ACTION,
    FOREIGN KEY (id_chutro) REFERENCES chutro(id_chutro) ON DELETE NO ACTION,
    FOREIGN KEY (id_nguoi_thue) REFERENCES nguoi_thue(id_nguoi_thue) ON DELETE NO ACTION
);

---
-- Tạo bảng dien (Tiền điện)
CREATE TABLE dien (
    id_dien VARCHAR(50) PRIMARY KEY,
    ngay_tao DATE NOT NULL,
    chi_so_dau DECIMAL(10, 2) NOT NULL,
    chi_so_cuoi DECIMAL(10, 2) NOT NULL,
    thanh_tien_dien DECIMAL(18, 2) NOT NULL,
    id_phong VARCHAR(50) NOT NULL,
    -- Ngăn xóa phòng trọ nếu đang có chỉ số điện liên quan.
    FOREIGN KEY (id_phong) REFERENCES phongtro(id_phong) ON DELETE NO ACTION
);

---
-- Tạo bảng nuoc (Tiền nước)
CREATE TABLE nuoc (
    id_nuoc VARCHAR(50) PRIMARY KEY,
    ngay_tao DATE NOT NULL,
    chi_so_dau DECIMAL(10, 2) NOT NULL,
    chi_so_cuoi DECIMAL(10, 2) NOT NULL,
    thanh_tien_nuoc DECIMAL(18, 2) NOT NULL,
    id_phong VARCHAR(50) NOT NULL,
    -- Ngăn xóa phòng trọ nếu đang có chỉ số nước liên quan.
    FOREIGN KEY (id_phong) REFERENCES phongtro(id_phong) ON DELETE NO ACTION
);

---
-- Tạo bảng hoadon (Hóa đơn)
CREATE TABLE hoadon (
    id_hoadon VARCHAR(50) PRIMARY KEY,
    ngay_tao DATE NOT NULL,
    trang_thai VARCHAR(50) NOT NULL,
    noi_dung TEXT,
    id_dien VARCHAR(50),
    id_lephi VARCHAR(50),
    id_nuoc VARCHAR(50),
    id_phong VARCHAR(50) NOT NULL,
    thanh_tien DECIMAL(18, 2) NOT NULL,
    -- Nếu chi tiết bị xóa, cột sẽ đặt là NULL
    FOREIGN KEY (id_dien) REFERENCES dien(id_dien) ON DELETE SET NULL,
    FOREIGN KEY (id_lephi) REFERENCES lephi(id_lephi) ON DELETE SET NULL,
    FOREIGN KEY (id_nuoc) REFERENCES nuoc(id_nuoc) ON DELETE SET NULL,
    -- Ngăn xóa phòng trọ nếu đang có hóa đơn liên quan.
    FOREIGN KEY (id_phong) REFERENCES phongtro(id_phong) ON DELETE NO ACTION
);

---
-- Tạo bảng thanh_toan (Thanh toán)
CREATE TABLE thanh_toan (
    id_thanh_toan VARCHAR(50) PRIMARY KEY,
    id_nguoi_thue VARCHAR(50) NOT NULL,
    id_hoadon VARCHAR(50) NOT NULL UNIQUE,
    FOREIGN KEY (id_nguoi_thue) REFERENCES nguoi_thue(id_nguoi_thue) ON DELETE NO ACTION,
    -- Nếu hóa đơn bị xóa, bản ghi thanh toán cũng bị xóa theo.
    FOREIGN KEY (id_hoadon) REFERENCES hoadon(id_hoadon) ON DELETE CASCADE
);