--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 13.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
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
-- Name: product; Type: TABLE; Schema: public; Owner: tasian
--

CREATE TABLE public.product (
    name character varying(255),
    vendorcode integer NOT NULL,
    cost integer,
    description text,
    stock_availability boolean,
    warehouse_number integer
);


ALTER TABLE public.product OWNER TO tasian;

--
-- Name: product_vendorcode_seq; Type: SEQUENCE; Schema: public; Owner: tasian
--

CREATE SEQUENCE public.product_vendorcode_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.product_vendorcode_seq OWNER TO tasian;

--
-- Name: product_vendorcode_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: tasian
--

ALTER SEQUENCE public.product_vendorcode_seq OWNED BY public.product.vendorcode;


--
-- Name: warehouse; Type: TABLE; Schema: public; Owner: tasian
--

CREATE TABLE public.warehouse (
    number integer NOT NULL,
    city character varying(255),
    adress text
);


ALTER TABLE public.warehouse OWNER TO tasian;

--
-- Name: warehouse_number_seq; Type: SEQUENCE; Schema: public; Owner: tasian
--

CREATE SEQUENCE public.warehouse_number_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.warehouse_number_seq OWNER TO tasian;

--
-- Name: warehouse_number_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: tasian
--

ALTER SEQUENCE public.warehouse_number_seq OWNED BY public.warehouse.number;


--
-- Name: product vendorcode; Type: DEFAULT; Schema: public; Owner: tasian
--

ALTER TABLE ONLY public.product ALTER COLUMN vendorcode SET DEFAULT nextval('public.product_vendorcode_seq'::regclass);


--
-- Name: warehouse number; Type: DEFAULT; Schema: public; Owner: tasian
--

ALTER TABLE ONLY public.warehouse ALTER COLUMN number SET DEFAULT nextval('public.warehouse_number_seq'::regclass);


--
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: tasian
--

COPY public.product (name, vendorcode, cost, description, stock_availability, warehouse_number) FROM stdin;
covid	3	19	\N	t	1
iphone9	1	9999	\N	f	1
xiaomi	2	3	\N	f	1
\.


--
-- Data for Name: warehouse; Type: TABLE DATA; Schema: public; Owner: tasian
--

COPY public.warehouse (number, city, adress) FROM stdin;
1	Kazan	peterburgskaya 35
\.


--
-- Name: product_vendorcode_seq; Type: SEQUENCE SET; Schema: public; Owner: tasian
--

SELECT pg_catalog.setval('public.product_vendorcode_seq', 3, true);


--
-- Name: warehouse_number_seq; Type: SEQUENCE SET; Schema: public; Owner: tasian
--

SELECT pg_catalog.setval('public.warehouse_number_seq', 1, true);


--
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: tasian
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (vendorcode);


--
-- Name: warehouse warehouse_pkey; Type: CONSTRAINT; Schema: public; Owner: tasian
--

ALTER TABLE ONLY public.warehouse
    ADD CONSTRAINT warehouse_pkey PRIMARY KEY (number);


--
-- Name: product product_warehouse_number_fkey; Type: FK CONSTRAINT; Schema: public; Owner: tasian
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_warehouse_number_fkey FOREIGN KEY (warehouse_number) REFERENCES public.warehouse(number);


--
-- PostgreSQL database dump complete
--

