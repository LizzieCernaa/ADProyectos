-- Tabla Estados
CREATE TABLE estados (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255)
);

-- Tabla Proyectos
CREATE TABLE proyectos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255),
    fecha_inicio DATE,
    fecha_finalizacion DATE,
    id_estado INT,
    FOREIGN KEY (id_estado) REFERENCES estados(id)
);

-- Tabla Roles
CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100)
);

-- Tabla Colaboradores
CREATE TABLE colaboradores (
    id SERIAL PRIMARY KEY,
    nombres VARCHAR(255),
    apellidos VARCHAR(255),
    correo VARCHAR(100)
);

-- Tabla Tareas
CREATE TABLE tareas (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255),
    fecha_inicio DATE,
    fecha_vencimiento DATE,
    id_estado INT,
    id_proyecto INT,
    FOREIGN KEY (id_estado) REFERENCES estados(id),
    FOREIGN KEY (id_proyecto) REFERENCES proyectos(id)
);


-- Tabla Roles_Proyecto
CREATE TABLE roles_proyecto (
    id SERIAL PRIMARY KEY,
    id_proyecto INT,
    id_role INT,
    id_colaborador INT,
    FOREIGN KEY (id_proyecto) REFERENCES proyectos(id),
    FOREIGN KEY (id_role) REFERENCES roles(id),
    FOREIGN KEY (id_colaborador) REFERENCES colaboradores(id)
);



-- Tabla Asignaciones
CREATE TABLE asignaciones (
    id SERIAL PRIMARY KEY,
    id_tarea INT,
    id_colaborador INT,
    FOREIGN KEY (id_tarea) REFERENCES tareas(id),
    FOREIGN KEY (id_colaborador) REFERENCES colaboradores(id)
);