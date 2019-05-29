#!/bin/bash

source ./lib/lib_menu.sh

echo "   _____________________________________________  "
echo "   |                                           | "
echo "   |                                           | "
echo "   |           ABM usuarios y grupos           | "
echo "   |                  por Bit                  | "
echo "   |                                           | "
echo "   |___________________________________________| "
		
nombres=('Agregar_usuario' 'Modificar_usuarios' 'Eliminar_usuarios' 'Listar_usuarios' 'Agregar_grupo' 'editar_grupo' 'eliminar_grupo' 'Listar_grupo' 'Editar_preferencias')

direciones=('./sub_shell/agregarUsuario.sh ' './sub_shell/ModificarUsuario.sh' './sub_shell/eliminarUsuario.sh' './sub_shell/listarUsuarios.sh' './sub_shell/agregarGrupo.sh' './sub_shell/ModificarGrupo.sh' './sub_shell/EliminarGrupo.sh' './sub_shell/listarGrupos.sh' './sub_shell/Preferencias.sh')

menu 'nombres[@]' 'direciones[@]' 
