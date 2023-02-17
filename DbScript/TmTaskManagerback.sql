--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 14.1

-- Started on 2023-02-10 19:31:33

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
-- TOC entry 209 (class 1259 OID 48576)
-- Name: comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment (
    id integer NOT NULL,
    task_id bigint NOT NULL,
    comment_history_id bigint NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.comment OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 48585)
-- Name: comment_history; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment_history (
    id integer NOT NULL,
    comment text NOT NULL,
    comment_type integer NOT NULL,
    reminder_date timestamp without time zone NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.comment_history OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 48583)
-- Name: comment_history_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_history_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_history_id_seq OWNER TO postgres;

--
-- TOC entry 3060 (class 0 OID 0)
-- Dependencies: 210
-- Name: comment_history_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_history_id_seq OWNED BY public.comment_history.id;


--
-- TOC entry 208 (class 1259 OID 48574)
-- Name: comment_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_id_seq OWNER TO postgres;

--
-- TOC entry 3061 (class 0 OID 0)
-- Dependencies: 208
-- Name: comment_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_id_seq OWNED BY public.comment.id;


--
-- TOC entry 213 (class 1259 OID 48596)
-- Name: comment_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment_type (
    id integer NOT NULL,
    name text NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.comment_type OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 48594)
-- Name: comment_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_type_id_seq OWNER TO postgres;

--
-- TOC entry 3062 (class 0 OID 0)
-- Dependencies: 212
-- Name: comment_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_type_id_seq OWNED BY public.comment_type.id;


--
-- TOC entry 205 (class 1259 OID 48528)
-- Name: status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.status (
    id integer NOT NULL,
    name text NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.status OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 48526)
-- Name: status_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.status_id_seq OWNER TO postgres;

--
-- TOC entry 3063 (class 0 OID 0)
-- Dependencies: 204
-- Name: status_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.status_id_seq OWNED BY public.status.id;


--
-- TOC entry 201 (class 1259 OID 48506)
-- Name: task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task (
    id integer NOT NULL,
    title text NOT NULL,
    description text NOT NULL,
    task_type integer NOT NULL,
    status_id integer NOT NULL,
    assigned_to bigint NOT NULL,
    created_date timestamp without time zone NOT NULL,
    required_date timestamp without time zone,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.task OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 48504)
-- Name: task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.task_id_seq OWNER TO postgres;

--
-- TOC entry 3064 (class 0 OID 0)
-- Dependencies: 200
-- Name: task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.task_id_seq OWNED BY public.task.id;


--
-- TOC entry 203 (class 1259 OID 48517)
-- Name: task_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task_type (
    id integer NOT NULL,
    name text NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public.task_type OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 48515)
-- Name: task_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.task_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.task_type_id_seq OWNER TO postgres;

--
-- TOC entry 3065 (class 0 OID 0)
-- Dependencies: 202
-- Name: task_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.task_type_id_seq OWNED BY public.task_type.id;


--
-- TOC entry 207 (class 1259 OID 48539)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    name text NOT NULL,
    created_on timestamp without time zone NOT NULL,
    updated_on timestamp without time zone NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 48537)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO postgres;

--
-- TOC entry 3066 (class 0 OID 0)
-- Dependencies: 206
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 2896 (class 2604 OID 48579)
-- Name: comment id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment ALTER COLUMN id SET DEFAULT nextval('public.comment_id_seq'::regclass);


--
-- TOC entry 2897 (class 2604 OID 48588)
-- Name: comment_history id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_history ALTER COLUMN id SET DEFAULT nextval('public.comment_history_id_seq'::regclass);


--
-- TOC entry 2898 (class 2604 OID 48599)
-- Name: comment_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_type ALTER COLUMN id SET DEFAULT nextval('public.comment_type_id_seq'::regclass);


--
-- TOC entry 2894 (class 2604 OID 48531)
-- Name: status id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status ALTER COLUMN id SET DEFAULT nextval('public.status_id_seq'::regclass);


--
-- TOC entry 2892 (class 2604 OID 48509)
-- Name: task id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);


--
-- TOC entry 2893 (class 2604 OID 48520)
-- Name: task_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task_type ALTER COLUMN id SET DEFAULT nextval('public.task_type_id_seq'::regclass);


--
-- TOC entry 2895 (class 2604 OID 48542)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 2915 (class 2606 OID 48593)
-- Name: comment_history comment_history_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_history
    ADD CONSTRAINT comment_history_pkey PRIMARY KEY (id);


--
-- TOC entry 2911 (class 2606 OID 48581)
-- Name: comment comment_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_pkey PRIMARY KEY (id);


--
-- TOC entry 2918 (class 2606 OID 48604)
-- Name: comment_type comment_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_type
    ADD CONSTRAINT comment_type_pkey PRIMARY KEY (id);


--
-- TOC entry 2907 (class 2606 OID 48536)
-- Name: status status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status
    ADD CONSTRAINT status_pkey PRIMARY KEY (id);


--
-- TOC entry 2903 (class 2606 OID 48514)
-- Name: task task_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_pkey PRIMARY KEY (id);


--
-- TOC entry 2905 (class 2606 OID 48525)
-- Name: task_type task_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task_type
    ADD CONSTRAINT task_type_pkey PRIMARY KEY (id);


--
-- TOC entry 2909 (class 2606 OID 48547)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 2912 (class 1259 OID 48610)
-- Name: fki_comment_history_id_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_comment_history_id_FK" ON public.comment USING btree (comment_history_id);


--
-- TOC entry 2913 (class 1259 OID 48622)
-- Name: fki_comment_task_taskid_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_comment_task_taskid_FK" ON public.comment USING btree (task_id);


--
-- TOC entry 2916 (class 1259 OID 48616)
-- Name: fki_history_type_typeid_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_history_type_typeid_FK" ON public.comment_history USING btree (comment_type);


--
-- TOC entry 2899 (class 1259 OID 48559)
-- Name: fki_task_status_statusid_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_task_status_statusid_FK" ON public.task USING btree (status_id);


--
-- TOC entry 2900 (class 1259 OID 48553)
-- Name: fki_task_type_typeid_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_task_type_typeid_FK" ON public.task USING btree (task_type);


--
-- TOC entry 2901 (class 1259 OID 48565)
-- Name: fki_task_user_userid_FK; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_task_user_userid_FK" ON public.task USING btree (assigned_to);


--
-- TOC entry 2922 (class 2606 OID 48605)
-- Name: comment comment_history_id_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "comment_history_id_FK" FOREIGN KEY (comment_history_id) REFERENCES public.comment_history(id) NOT VALID;


--
-- TOC entry 2923 (class 2606 OID 48617)
-- Name: comment comment_task_taskid_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "comment_task_taskid_FK" FOREIGN KEY (task_id) REFERENCES public.task(id) NOT VALID;


--
-- TOC entry 2924 (class 2606 OID 48611)
-- Name: comment_history history_type_typeid_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment_history
    ADD CONSTRAINT "history_type_typeid_FK" FOREIGN KEY (comment_type) REFERENCES public.comment_type(id) NOT VALID;


--
-- TOC entry 2920 (class 2606 OID 48554)
-- Name: task task_status_statusid_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "task_status_statusid_FK" FOREIGN KEY (status_id) REFERENCES public.status(id) NOT VALID;


--
-- TOC entry 2919 (class 2606 OID 48548)
-- Name: task task_type_typeid_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "task_type_typeid_FK" FOREIGN KEY (task_type) REFERENCES public.task_type(id) NOT VALID;


--
-- TOC entry 2921 (class 2606 OID 48560)
-- Name: task task_user_userid_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT "task_user_userid_FK" FOREIGN KEY (assigned_to) REFERENCES public."user"(id) NOT VALID;


-- Completed on 2023-02-10 19:31:33

--
-- PostgreSQL database dump complete
--

