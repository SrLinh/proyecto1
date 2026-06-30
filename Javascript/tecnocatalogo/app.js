const productos = [
  {
    id: 1,
    nombre: "Laptop Lenovo IdeaPad 3",
    categoria: "Computadoras",
    precio: 699.99,
    estado: "Disponible",
    imagen: "img/lenovo-ideapad3.jpg",
    descripcion: "Laptop con procesador Intel Core i5, 8 GB de RAM y SSD de 512 GB."
  },
  {
    id: 2,
    nombre: "Mouse Logitech G203",
    categoria: "Accesorios",
    precio: 29.99,
    estado: "Oferta",
    imagen: "img/logitech-g203.jpg",
    descripcion: "Mouse gamer con iluminación RGB y 6 botones programables."
  },
  {
    id: 3,
    nombre: "Audífonos Sony WH-CH520",
    categoria: "Audio",
    precio: 79.99,
    estado: "Disponible",
    imagen: "img/sony-whch520.jpg",
    descripcion: "Audífonos inalámbricos con hasta 50 horas de batería."
  },
  {
    id: 4,
    nombre: "Monitor Samsung 24''",
    categoria: "Monitores",
    precio: 189.99,
    estado: "Agotado",
    imagen: "img/monitor-samsung24.jpg",
    descripcion: "Monitor Full HD de 24 pulgadas con panel IPS."
  },
  {
    id: 5,
    nombre: "Teclado Mecánico Redragon K552",
    categoria: "Accesorios",
    precio: 59.99,
    estado: "Disponible",
    imagen: "img/redragon-k552.jpg",
    descripcion: "Teclado mecánico con retroiluminación LED y switches azules."
  },
  {
    id: 6,
    nombre: "PC Gamer Ryzen 5",
    categoria: "Computadoras",
    precio: 999.99,
    estado: "Oferta",
    imagen: "img/pc-gamer-ryzen5.jpg",
    descripcion: "Computadora de escritorio con Ryzen 5, 16 GB RAM y RTX 4060."
  },
  {
    id: 7,
    nombre: "Bocina JBL Flip 6",
    categoria: "Audio",
    precio: 119.99,
    estado: "Disponible",
    imagen: "img/jbl-flip6.jpg",
    descripcion: "Bocina Bluetooth portátil resistente al agua con sonido potente."
  },
  {
    id: 8,
    nombre: "Monitor LG UltraWide 29''",
    categoria: "Monitores",
    precio: 279.99,
    estado: "Disponible",
    imagen: "img/lg-ultrawide29.jpg",
    descripcion: "Monitor UltraWide Full HD ideal para productividad y entretenimiento."
  }
];


cantidadProductos();

function cantidadProductos(){
    let largoProductos = productos.length;
    console.log(largoProductos);

    let badgeproducto = document.getElementById("badgeProductos");
    badgeproducto.textContent = largoProductos;
}