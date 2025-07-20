<template>
  <div class="min-h-screen bg-gray-100">
    <Header/>
    <main class="h-full w-full px-4 sm:px-0">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-6">Gerenciamento de Usuários</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border border-gray-200 shadow-md rounded-md overflow-hidden">
          <div class="bg-gray-700 text-white w-full flex justify-center p-2 font-semibold text-lg">
            Usuários Cadastrados
          </div>

          <div class="p-4" v-if="!usuarioStore.loading">
            <table class="min-w-full text-left text-sm">
              <thead class="text-xs uppercase bg-gray-200 text-gray-600">
              <tr>
                <th class="px-4 py-2">ID</th>
                <th class="px-4 py-2">Nome</th>
                <th class="px-4 py-2 text-end">Ações</th>
              </tr>
              </thead>
              <tbody>
              <tr
                  v-for="user in usuarioStore.usuarios"
                  :key="user.id"
                  class="border-b hover:bg-gray-50"
              >
                <td class="px-4 py-2">{{ user.id }}</td>
                <td class="px-4 py-2">{{ user.nome }}</td>
                <td class="px-4 py-2 text-right space-x-2">
                  <button
                      class="bg-green-500 hover:bg-green-600 text-white px-3 py-1 rounded"
                  >
                    Editar
                  </button>
                  <button
                      class="bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded"
                      @click="deletarUsuario(user.id)"
                  >
                    Deletar
                  </button>
                </td>
              </tr>
              </tbody>
            </table>
            <p v-if="usuarioStore.usuarios.length === 0" class="text-center mt-4 text-gray-500">
              Nenhum usuário cadastrado.
            </p>
          </div>

          <div v-else class="p-4 text-center text-gray-600">Carregando...</div>
        </div>
        <p class="py-4 text-md text-gray-700">
          <router-link to="/usuarios/cadastrar">Cadastrar usuário</router-link>
        </p>
      </div>
    </main>
  </div>
</template>


<script lang="ts">
import {useUsuarioStore} from "@/stores/usuarioStore.ts";
import {onMounted} from "vue";
import Header from "@/components/Header.vue";
import type {Usuario} from "@/services/interfaces/UsuarioInterface.ts";

export default {
  components: {Header},
  setup() {
    const usuarioStore = useUsuarioStore();

    const editarUsuario = async (usuario: Usuario): Promise<void> => {
      await usuarioStore.editUsuario(usuario);
    }

    const deletarUsuario = async (id: number): Promise<void> => {
      await usuarioStore.deletarUsuario(id);
      alert("Usuario deletado.");
    }

    onMounted(async (): Promise<void> => {
      await usuarioStore.fetchUsuarios();
    })

    return {
      usuarioStore,
      deletarUsuario
    }
  }
}
</script>