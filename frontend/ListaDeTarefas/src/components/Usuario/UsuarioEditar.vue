<template>
  <div class="min-h-screen bg-gray-100">
    <Header/>
    <main class="h-full w-full px-4 sm:px-0">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-6">Editar Usuário</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border border-gray-200 shadow-md rounded-md overflow-hidden">
          <div class="bg-gray-700 text-white w-full flex justify-center p-2 font-semibold text-lg">
            Formulário de edição
          </div>
          <div class="flex flex-col items-center p-4">
            <label class="font-medium mb-1">Alterar nome de usuário</label>
            <form @submit.prevent>
              <input type="text"
                     class="bg-gray-200 border-none rounded-sm px-2 py-1 min-w-[250px] focus:outline-none text-sm"
                     maxlength="80"
                     v-model="nomeUsuario"
              >
            </form>
            <button
                type="submit"
                class="bg-green-500 font-semibold hover:bg-green-600 text-white px-2 py-1 border-none rounded-sm mt-3 cursor-pointer "
                @click="editarUsuario()"
            >
              Editar
            </button>
          </div>
        </div>
        <p class="py-4 text-md text-gray-700">
          <router-link to="/usuarios">Voltar</router-link>
        </p>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import {useRoute} from "vue-router";
import Header from "@/components/Header.vue";
import {onMounted, ref} from "vue";
import {useUsuarioStore} from "@/stores/usuarioStore.ts";
import type {Usuario} from "@/services/interfaces/UsuarioInterface.ts";
import router from "@/router";

export default {
  components: {Header},
  setup() {
    const route = useRoute();
    const usuarioStore = useUsuarioStore();
    const usuarioId = Number(route.params.usuarioId);
    const nomeUsuario = ref<string>()

    const editarUsuario = async (): Promise<void> => {
      try {
        const usuario: Usuario = {nome: nomeUsuario.value, id: usuarioId}
        await usuarioStore.editUsuario(usuario);
        setTimeout(() => {
          alert("Usuário editado.");
          router.push('/usuarios');
        }, 500);
      } catch {
        alert("Erro ao editar usuário.")
      } finally {
        nomeUsuario.value = "";
      }
    }

    onMounted(async (): Promise<void> => {
      await usuarioStore.buscarUsuarioPorId(usuarioId);
      nomeUsuario.value = usuarioStore.usuarioSelecionado?.nome;
    })

    return {
      nomeUsuario,
      usuarioStore,
      editarUsuario
    }
  }
}
</script>