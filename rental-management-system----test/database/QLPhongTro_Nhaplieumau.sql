use quanlyphongtro;

--- thêm 1 chủ trọ
insert into chutro (id_chutro, hoten, sdt, email, diachi, taikhoan, matkhau) values
(1, N'nguyễn văn a', '0912345678', 'nguyenvana@gmail.com', N'số 123, đường abc, hà nội', 'chutro_a', 'pass_a');

--- thêm 10 phòng trọ
insert into phongtro (id_phong, id_chutro, tenphong, giaphong, tinhtrang) values
(1, 1, N'p101', 2500000.00, N'đã có người thuê'),
(2, 1, N'p102', 2800000.00, N'đã có người thuê'),
(3, 1, N'p103', 3000000.00, N'đã có người thuê'),
(4, 1, N'p104', 2700000.00, N'đã có người thuê'),
(5, 1, N'p201', 3200000.00, N'đã có người thuê'),
(6, 1, N'p202', 2900000.00, N'đã có người thuê'),
(7, 1, N'p203', 2600000.00, N'đã có người thuê'),
(8, 1, N'p204', 3100000.00, N'đã có người thuê'),
(9, 1, N'p301', 3500000.00, N'đã có người thuê'),
(10, 1, N'p302', 3300000.00, N'đã có người thuê');

--- thêm 20 người thuê (chia đều cho 10 phòng)
insert into nguoithue (id_nguoithue, id_phong, hoten, cccd, sdt, email, taikhoan, matkhau) values
(1, 1, N'trần thị b', '001122334455', '0901234567', 'tranthib@gmail.com', 'nguoithue_b', 'pass_b'),
(2, 1, N'lê văn c', '001122334466', '0902345678', 'levanc@gmail.com', 'nguoithue_c', 'pass_c'),
(3, 2, N'phạm văn d', '001122334477', '0903456789', 'phamvand@gmail.com', 'nguoithue_d', 'pass_d'),
(4, 2, N'hoàng thị e', '001122334488', '0904567890', 'hoangthie@gmail.com', 'nguoithue_e', 'pass_e'),
(5, 3, N'đỗ minh f', '001122334499', '0905678901', 'dominhf@gmail.com', 'nguoithue_f', 'pass_f'),
(6, 3, N'nguyễn thu g', '001122335500', '0906789012', 'nguyenthu_g@gmail.com', 'nguoithue_g', 'pass_g'),
(7, 4, N'võ văn h', '001122335511', '0907890123', 'vovanh@gmail.com', 'nguoithue_h', 'pass_h'),
(8, 4, N'đặng thị i', '001122335522', '0908901234', 'dangthi_i@gmail.com', 'nguoithue_i', 'pass_i'),
(9, 5, N'bùi quang k', '001122335533', '0909012345', 'buiquangk@gmail.com', 'nguoithue_k', 'pass_k'),
(10, 5, N'trịnh thị l', '001122335544', '0901123456', 'trinhthil@gmail.com', 'nguoithue_l', 'pass_l'),
(11, 6, N'lý văn m', '001122335555', '0902234567', 'lyvanm@gmail.com', 'nguoithue_m', 'pass_m'),
(12, 6, N'mai thị n', '001122335566', '0903345678', 'maithin@gmail.com', 'nguoithue_n', 'pass_n'),
(13, 7, N'phan văn p', '001122335577', '0904456789', 'phanvanp@gmail.com', 'nguoithue_p', 'pass_p'),
(14, 7, N'hồ thị q', '001122335588', '0905567890', 'hothi_q@gmail.com', 'nguoithue_q', 'pass_q'),
(15, 8, N'lương văn r', '001122335599', '0906678901', 'luongvanr@gmail.com', 'nguoithue_r', 'pass_r'),
(16, 8, N'nguyễn thị s', '001122336600', '0907789012', 'nguyenthis@gmail.com', 'nguoithue_s', 'pass_s'),
(17, 9, N'vũ thị t', '001122336611', '0908890123', 'vuthit@gmail.com', 'nguoithue_t', 'pass_t'),
(18, 9, N'trần văn u', '001122336622', '0909901234', 'tranvanu@gmail.com', 'nguoithue_u', 'pass_u'),
(19, 10, N'đỗ thị v', '001122336633', '0900012345', 'dothiv@gmail.com', 'nguoithue_v', 'pass_v'),
(20, 10, N'hoàng văn x', '001122336644', '0901112233', 'hoangvanx@gmail.com', 'nguoithue_x', 'pass_x');

--- thêm 10 hợp đồng
insert into hopdong (id_hopdong, id_phong, id_chutro, id_nguoithue, ngaybatdau, ngayketthuc, tiencoc) values
(1, 1, 1, 1, '2024-01-01', '2025-01-01', 2500000.00),
(2, 2, 1, 3, '2024-01-05', '2025-01-05', 2800000.00),
(3, 3, 1, 5, '2024-02-10', '2025-02-10', 3000000.00),
(4, 4, 1, 7, '2024-02-15', '2025-02-15', 2700000.00),
(5, 5, 1, 9, '2024-03-20', '2025-03-20', 3200000.00),
(6, 6, 1, 11, '2024-03-25', '2025-03-25', 2900000.00),
(7, 7, 1, 13, '2024-04-01', '2025-04-01', 2600000.00),
(8, 8, 1, 15, '2024-04-05', '2025-04-05', 3100000.00),
(9, 9, 1, 17, '2024-05-10', '2025-05-10', 3500000.00),
(10, 10, 1, 19, '2024-01-01', '2025-01-01', 2500000.00),
(11, 1, 1, 2, '2024-01-05', '2025-01-05', 2800000.00),
(12, 2, 1, 4, '2024-02-10', '2025-02-10', 3000000.00),
(13, 3, 1, 6, '2024-02-15', '2025-02-15', 2700000.00),
(14, 4, 1, 8, '2024-03-20', '2025-03-20', 3200000.00),
(15, 5, 1, 10, '2024-03-25', '2025-03-25', 2900000.00),
(16, 6, 1, 12, '2024-04-01', '2025-04-01', 2600000.00),
(17, 7, 1, 14, '2024-04-05', '2025-04-05', 3100000.00),
(18, 8, 1, 16, '2024-05-10', '2025-05-10', 3500000.00),
(19, 9, 1, 18, '2024-05-15', '2025-05-15', 3300000.00),
(20, 10, 1, 20, '2024-05-15', '2025-05-15', 3300000.00);

--- thêm 10 lệ phí
insert into lephi (id_lephi, ngaytao, tienphong, tiendv, thanhtien_lephi) values
(1, '2024-09-01', 2500000.00, 100000.00, 2600000.00),
(2, '2024-09-01', 2800000.00, 120000.00, 2920000.00),
(3, '2024-09-01', 3000000.00, 150000.00, 3150000.00),
(4, '2024-09-01', 2700000.00, 110000.00, 2810000.00),
(5, '2024-09-01', 3200000.00, 180000.00, 3380000.00),
(6, '2024-09-01', 2900000.00, 130000.00, 3030000.00),
(7, '2024-09-01', 2600000.00, 100000.00, 2700000.00),
(8, '2024-09-01', 3100000.00, 160000.00, 3260000.00),
(9, '2024-09-01', 3500000.00, 200000.00, 3700000.00),
(10, '2024-09-01', 3300000.00, 170000.00, 3470000.00);

--- thêm 10 tiền điện
insert into dien (id_dien, ngaytao, chiso_dau, chiso_cuoi, thanhtien_dien) values
(1, '2024-09-01', 100.00, 150.00, (150-100)*3000.00),
(2, '2024-09-01', 120.00, 175.00, (175-120)*3000.00),
(3, '2024-09-01', 150.00, 210.00, (210-150)*3000.00),
(4, '2024-09-01', 90.00, 140.00, (140-90)*3000.00),
(5, '2024-09-01', 180.00, 250.00, (250-180)*3000.00),
(6, '2024-09-01', 110.00, 165.00, (165-110)*3000.00),
(7, '2024-09-01', 95.00, 145.00, (145-95)*3000.00),
(8, '2024-09-01', 160.00, 220.00, (220-160)*3000.00),
(9, '2024-09-01', 200.00, 280.00, (280-200)*3000.00),
(10, '2024-09-01', 170.00, 240.00, (240-170)*3000.00);

--- thêm 10 tiền nước
insert into nuoc (id_nuoc, ngaytao, chiso_dau, chiso_cuoi, thanhtien_nuoc) values
(1, '2024-09-01', 20.00, 25.00, (25-20)*10000.00),
(2, '2024-09-01', 25.00, 32.00, (32-25)*10000.00),
(3, '2024-09-01', 30.00, 40.00, (40-30)*10000.00),
(4, '2024-09-01', 15.00, 20.00, (20-15)*10000.00),
(5, '2024-09-01', 35.00, 48.00, (48-35)*10000.00),
(6, '2024-09-01', 22.00, 28.00, (28-22)*10000.00),
(7, '2024-09-01', 18.00, 24.00, (24-18)*10000.00),
(8, '2024-09-01', 38.00, 45.00, (45-38)*10000.00),
(9, '2024-09-01', 42.00, 55.00, (55-42)*10000.00),
(10, '2024-09-01', 30.00, 38.00, (38-30)*10000.00);

--- thêm 10 hóa đơn
insert into hoadon (id_hoadon, ngaytao, trangthai, noidung, id_lephi, id_dien, id_nuoc, id_phong, thanhtien) values
(1, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 1, 1, 1, 1, (select thanhtien_lephi from lephi where id_lephi = 1) + (select thanhtien_dien from dien where id_dien = 1) + (select thanhtien_nuoc from nuoc where id_nuoc = 1)),
(2, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 2, 2, 2, 2, (select thanhtien_lephi from lephi where id_lephi = 2) + (select thanhtien_dien from dien where id_dien = 2) + (select thanhtien_nuoc from nuoc where id_nuoc = 2)),
(3, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 3, 3, 3, 3, (select thanhtien_lephi from lephi where id_lephi = 3) + (select thanhtien_dien from dien where id_dien = 3) + (select thanhtien_nuoc from nuoc where id_nuoc = 3)),
(4, '2024-09-05', N'chưa thanh toán', N'hóa đơn tháng 9', 4, 4, 4, 4, (select thanhtien_lephi from lephi where id_lephi = 4) + (select thanhtien_dien from dien where id_dien = 4) + (select thanhtien_nuoc from nuoc where id_nuoc = 4)),
(5, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 5, 5, 5, 5, (select thanhtien_lephi from lephi where id_lephi = 5) + (select thanhtien_dien from dien where id_dien = 5) + (select thanhtien_nuoc from nuoc where id_nuoc = 5)),
(6, '2024-09-05', N'chưa thanh toán', N'hóa đơn tháng 9', 6, 6, 6, 6, (select thanhtien_lephi from lephi where id_lephi = 6) + (select thanhtien_dien from dien where id_dien = 6) + (select thanhtien_nuoc from nuoc where id_nuoc = 6)),
(7, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 7, 7, 7, 7, (select thanhtien_lephi from lephi where id_lephi = 7) + (select thanhtien_dien from dien where id_dien = 7) + (select thanhtien_nuoc from nuoc where id_nuoc = 7)),
(8, '2024-09-05', N'chưa thanh toán', N'hóa đơn tháng 9', 8, 8, 8, 8, (select thanhtien_lephi from lephi where id_lephi = 8) + (select thanhtien_dien from dien where id_dien = 8) + (select thanhtien_nuoc from nuoc where id_nuoc = 8)),
(9, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 9, 9, 9, 9, (select thanhtien_lephi from lephi where id_lephi = 9) + (select thanhtien_dien from dien where id_dien = 9) + (select thanhtien_nuoc from nuoc where id_nuoc = 9)),
(10, '2024-09-05', N'đã thanh toán', N'hóa đơn tháng 9', 10, 10, 10, 10, (select thanhtien_lephi from lephi where id_lephi = 10) + (select thanhtien_dien from dien where id_dien = 10) + (select thanhtien_nuoc from nuoc where id_nuoc = 10));

--- thêm 10 bản ghi thanh toán cho 10 người thuê
insert into thanhtoan (id_hoadon, id_nguoithue, ngaythanhtoan) values
(1, 1, '2024-09-05'),
(2, 3, '2024-09-05'),
(3, 5, '2024-09-05'),
(4, 7, null),
(5, 9, '2024-09-05'),
(6, 11, null),
(7, 13, '2024-09-05'),
(8, 15, null),
(9, 17, '2024-09-05'),
(10, 19, '2024-09-05');

