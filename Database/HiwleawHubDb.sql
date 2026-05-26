--
-- PostgreSQL database dump
--

\restrict PTZUX2LzohYT8qizD90GUkF2HpFEyNhmjQv8QEOzXdZDcWkxQBXoqNbxPdnRelu

-- Dumped from database version 18.3
-- Dumped by pg_dump version 18.3

-- Started on 2026-05-17 22:54:53

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 225 (class 1259 OID 16489)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- TOC entry 222 (class 1259 OID 16458)
-- Name: menus; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.menus (
    id integer NOT NULL,
    restaurant_id integer,
    name character varying(100) NOT NULL,
    price numeric(10,2) NOT NULL,
    "ImageUrl" text
);


--
-- TOC entry 221 (class 1259 OID 16457)
-- Name: menus_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.menus_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 5043 (class 0 OID 0)
-- Dependencies: 221
-- Name: menus_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.menus_id_seq OWNED BY public.menus.id;


--
-- TOC entry 220 (class 1259 OID 16447)
-- Name: restaurants; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.restaurants (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    description text,
    image_url text
);


--
-- TOC entry 219 (class 1259 OID 16446)
-- Name: restaurants_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.restaurants_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 5044 (class 0 OID 0)
-- Dependencies: 219
-- Name: restaurants_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.restaurants_id_seq OWNED BY public.restaurants.id;


--
-- TOC entry 224 (class 1259 OID 16473)
-- Name: reviews; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.reviews (
    id integer NOT NULL,
    menu_id integer,
    reviewer_name character varying(100) NOT NULL,
    rating integer,
    comment text,
    CONSTRAINT reviews_rating_check CHECK (((rating >= 1) AND (rating <= 5)))
);


--
-- TOC entry 223 (class 1259 OID 16472)
-- Name: reviews_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.reviews_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 5045 (class 0 OID 0)
-- Dependencies: 223
-- Name: reviews_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.reviews_id_seq OWNED BY public.reviews.id;


--
-- TOC entry 4871 (class 2604 OID 16461)
-- Name: menus id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.menus ALTER COLUMN id SET DEFAULT nextval('public.menus_id_seq'::regclass);


--
-- TOC entry 4870 (class 2604 OID 16450)
-- Name: restaurants id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.restaurants ALTER COLUMN id SET DEFAULT nextval('public.restaurants_id_seq'::regclass);


--
-- TOC entry 4872 (class 2604 OID 16476)
-- Name: reviews id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reviews ALTER COLUMN id SET DEFAULT nextval('public.reviews_id_seq'::regclass);


--
-- TOC entry 5037 (class 0 OID 16489)
-- Dependencies: 225
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 5034 (class 0 OID 16458)
-- Dependencies: 222
-- Data for Name: menus; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.menus VALUES (2, 1, 'ไก่ย่างครึ่งตัว', 90.00, '/images/b4861844-ded3-4a63-bfb9-b0d79a937954_4015a251a8574a19aaf83cd2d8255fe7.jpg');
INSERT INTO public.menus VALUES (6, 1, 'ต้มยำกุ้งน้ำข้น', 89.00, '/images/c28553dc-72d9-4112-aea5-48a16c9b43d8_ต้มยำกุ้ง.jpg');
INSERT INTO public.menus VALUES (5, 1, 'หมูย่างคลุกฝุ่น', 70.00, '/images/a6fd02c1-ab2e-43fa-b1a9-b2e6adea86c2_หมูย่าง.jpg');
INSERT INTO public.menus VALUES (1, 1, 'ตำไทยไข่เค็ม', 60.00, '/images/4bf5c6db-5bd5-4ce5-bc8b-f9c2dec0d4c4_ตำไทยไข่เค็ม.jpg');
INSERT INTO public.menus VALUES (3, 2, 'ข้าวกะเพราหมูสับ', 50.00, '/images/11235ab2-2f8f-4c22-a0ee-342a11f7fd52_shop1.jpg');
INSERT INTO public.menus VALUES (7, 2, 'ข้าวผัดไดโนเสาร์', 120.00, '/images/ab9a6d87-f118-4a00-866b-f1aa175c25a1_shop2.png');


--
-- TOC entry 5032 (class 0 OID 16447)
-- Dependencies: 220
-- Data for Name: restaurants; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.restaurants VALUES (2, 'ร้านกะเพราตาหนวด', 'เผ็ดดุดัน สั่งได้ตามใจ', '/images/11235ab2-2f8f-4c22-a0ee-342a11f7fd52_shop1.jpg');
INSERT INTO public.restaurants VALUES (1, 'ร้านส้มตำอินเตอร์', 'ส้มตำรสเด็ด ใจกลางเมือง', '/images/ab9a6d87-f118-4a00-866b-f1aa175c25a1_shop2.png');


--
-- TOC entry 5036 (class 0 OID 16473)
-- Dependencies: 224
-- Data for Name: reviews; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.reviews VALUES (1, 1, 'คุณสมชาย', 5, 'ส้มตำรสนัวมาก ไข่เค็มกำลังดี');
INSERT INTO public.reviews VALUES (2, 3, 'สายกินจุน', 5, 'กะเพราของแท้ไม่มีถั่วฝักยาว!');
INSERT INTO public.reviews VALUES (3, 1, 'น้องน้ำใส', 5, 'เผ็ดเปรี้ยวหวานกำลังดีเลยค่ะ!');
INSERT INTO public.reviews VALUES (5, 2, 'สมตุ๋ย', 2, 'รสชาติหมาไม่แดกเลยครับ');
INSERT INTO public.reviews VALUES (7, 7, 'FlintStone', 4, 'เนื้อไดโนเสาร์โคตรแซ่บ');


--
-- TOC entry 5046 (class 0 OID 0)
-- Dependencies: 221
-- Name: menus_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.menus_id_seq', 7, true);


--
-- TOC entry 5047 (class 0 OID 0)
-- Dependencies: 219
-- Name: restaurants_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.restaurants_id_seq', 2, true);


--
-- TOC entry 5048 (class 0 OID 0)
-- Dependencies: 223
-- Name: reviews_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.reviews_id_seq', 8, true);


--
-- TOC entry 4881 (class 2606 OID 16495)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4877 (class 2606 OID 16466)
-- Name: menus menus_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.menus
    ADD CONSTRAINT menus_pkey PRIMARY KEY (id);


--
-- TOC entry 4875 (class 2606 OID 16456)
-- Name: restaurants restaurants_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.restaurants
    ADD CONSTRAINT restaurants_pkey PRIMARY KEY (id);


--
-- TOC entry 4879 (class 2606 OID 16483)
-- Name: reviews reviews_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reviews
    ADD CONSTRAINT reviews_pkey PRIMARY KEY (id);


--
-- TOC entry 4882 (class 2606 OID 16467)
-- Name: menus menus_restaurant_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.menus
    ADD CONSTRAINT menus_restaurant_id_fkey FOREIGN KEY (restaurant_id) REFERENCES public.restaurants(id) ON DELETE CASCADE;


--
-- TOC entry 4883 (class 2606 OID 16484)
-- Name: reviews reviews_menu_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reviews
    ADD CONSTRAINT reviews_menu_id_fkey FOREIGN KEY (menu_id) REFERENCES public.menus(id) ON DELETE CASCADE;


-- Completed on 2026-05-17 22:54:53

--
-- PostgreSQL database dump complete
--

\unrestrict PTZUX2LzohYT8qizD90GUkF2HpFEyNhmjQv8QEOzXdZDcWkxQBXoqNbxPdnRelu

