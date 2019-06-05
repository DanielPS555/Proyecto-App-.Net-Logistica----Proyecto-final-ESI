#!/bin/bash
clear
source ./lib/lib_menu.sh
source lib/lib_error.sh
source lib/DT.sh
source lib/expiracionUsuario.sh
source lib/GP.sh
source lib/GS.sh
source lib/NDiasHasta.sh
source lib/pass.sh
source lib/shell.sh
source lib/UDI.sh
source ./sub_shell/agregarUsuario.sh 
source ./sub_shell/ModificarUsuario.sh 
source ./sub_shell/eliminarUsuario.sh 
source ./sub_shell/listarUsuarios.sh 
source ./sub_shell/agregarGrupo.sh 
source ./sub_shell/ModificarGrupo.sh 
source ./sub_shell/EliminarGrupo.sh 
source ./sub_shell/listarGrupos.sh 
source ./sub_shell/Preferencias.sh 
source ./sub_shell/ConfiguracionDelAmbienteDeTrabajo.sh 

respuesta="" #El dato pasado por los return solo puede ser numerico, entonces utilizamos una variable externa donde se cargen las salidas, como si fuera un $? pero con mayor capasidad 

echo "   _____________________________________________  "
echo "   |                                           | "
echo "   |                                           | "
echo "   |           ABM usuarios y grupos           | "
echo "   |                  por Bit                  | "
echo "   |                                           | "
echo "   |___________________________________________| "
echo "" 
		
nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias' 'Instalar')

direcionesSetUp=('agregarUsuario' 'ModificarUsuario' 'eliminarUsuario' 'listarUsuarios' 'agregarGrupo' 'ModificarGrupo' 'EliminarGrupo' 'listarGrupos' 'Preferencias' 'ConfiguracionDelAmbienteDeTrabajo')

menu 'nombres[@]' 'direcionesSetUp[@]'
