CREATE TABLE `Ventas` (
	`Id` BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
	`IdCampesino` BIGINT(20) UNSIGNED NOT NULL DEFAULT '0',
	`IdProducto` BIGINT(20) UNSIGNED NOT NULL DEFAULT '0',
	`Cantidad` INT(10) UNSIGNED NOT NULL DEFAULT '0',
	`Precio` INT(10) UNSIGNED NOT NULL DEFAULT '0',
	`Fecha` DATETIME NOT NULL,
	PRIMARY KEY (`Id`) USING BTREE,
	INDEX `FK_Venta_Campesino` (`IdCampesino`) USING BTREE,
	INDEX `FK_Venta_Producto` (`IdProducto`) USING BTREE,
	CONSTRAINT `FK_Venta_Campesino` FOREIGN KEY (`IdCampesino`) REFERENCES `POOGrupo4`.`Usuarios` (`Id`) ON UPDATE RESTRICT ON DELETE RESTRICT,
	CONSTRAINT `FK_Venta_Producto` FOREIGN KEY (`IdProducto`) REFERENCES `POOGrupo4`.`Productos` (`Id`) ON UPDATE RESTRICT ON DELETE RESTRICT
)
COLLATE='utf8mb4_unicode_ci'
ENGINE=InnoDB
AUTO_INCREMENT=10
;