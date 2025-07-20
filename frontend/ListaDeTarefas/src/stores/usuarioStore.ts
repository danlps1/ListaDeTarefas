import {defineStore} from 'pinia'
import {ref} from 'vue'
import * as usuarioService from '@/services/usuarioService'
import type {Usuario} from "@/services/interfaces/UsuarioInterface.ts";

export const useUsuarioStore = defineStore('usuario', () => {
    const usuarios = ref<Usuario[]>([])
    const usuarioSelecionado = ref<Usuario | null>(null)
    const loading = ref(false)
    const error = ref<string | null>(null)

    const fetchUsuarios = async (): Promise<void> => {
        loading.value = true
        error.value = null
        try {
            const res = await usuarioService.getUsuarios()
            usuarios.value = res.dados ?? []
        } catch (e) {
            error.value = 'Erro ao buscar usuários.'
            console.error(e)
        } finally {
            loading.value = false
        }
    }

    const buscarUsuarioPorId = async (usuarioId: number): Promise<void> => {
        loading.value = true
        error.value = null
        try {
            const res = await usuarioService.getUsuarioById(usuarioId)
            usuarioSelecionado.value = res.dados ?? null
        } catch (e) {
            error.value = 'Erro ao buscar usuário.'
            console.error(e)
        } finally {
            loading.value = false
        }
    }

    const addUsuario = async (usuario: Usuario): Promise<void> => {
        await usuarioService.createUsuario(usuario)
        await fetchUsuarios()
    }

    const editUsuario = async (usuario: Usuario): Promise<void> => {
        await usuarioService.editUsuario(usuario)
        await fetchUsuarios()
    }

    const deletarUsuario = async (usuarioId: number): Promise<void> => {
        await usuarioService.deletarUsuario(usuarioId)
        await fetchUsuarios()
    }

    return {
        usuarios,
        usuarioSelecionado,
        loading,
        error,
        fetchUsuarios,
        buscarUsuarioPorId,
        addUsuario,
        editUsuario,
        deletarUsuario
    }
})
