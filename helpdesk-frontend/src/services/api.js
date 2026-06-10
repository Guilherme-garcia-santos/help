import axios from 'axios'

// Cria uma instância do axios configurada com a baseURL e o token atual
function createClient(baseUrl, token) {
  const instance = axios.create({
    baseURL: baseUrl,
    headers: {
      'Content-Type': 'application/json',
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
    },
  })

  // Interceptor: extrai data da resposta e trata erros de forma padronizada
  instance.interceptors.response.use(
    (response) => response.data ?? null,
    (error) => {
      const message =
        error.response?.data?.message ||
        error.response?.data ||
        error.message ||
        `Erro ${error.response?.status}`
      return Promise.reject(new Error(message))
    }
  )

  return instance
}

// ─── AUTH ──────────────────────────────────────────────
export function login(baseUrl, email, senha) {
  return createClient(baseUrl, null).post('/api/auth/login', { email, senha })
}

// ─── ORDENS DE SERVIÇO ─────────────────────────────────
export function getOSs(baseUrl, token) {
  return createClient(baseUrl, token).get('/api/oss')
}

export function getOS(baseUrl, token, id) {
  return createClient(baseUrl, token).get(`/api/oss/${id}`)
}

export function createOS(baseUrl, token, data) {
  return createClient(baseUrl, token).post('/api/oss', data)
}

export function updateOS(baseUrl, token, id, data) {
  return createClient(baseUrl, token).put(`/api/oss/${id}`, data)
}

export function deleteOS(baseUrl, token, id) {
  return createClient(baseUrl, token).delete(`/api/oss/${id}`)
}

// ─── USUÁRIOS ──────────────────────────────────────────
export function getUsuarios(baseUrl, token) {
  return createClient(baseUrl, token).get('/api/usuarios')
}

export function getUsuario(baseUrl, token, id) {
  return createClient(baseUrl, token).get(`/api/usuarios/${id}`)
}

export function createUsuario(baseUrl, token, data) {
  return createClient(baseUrl, token).post('/api/usuarios', data)
}

export function updateUsuario(baseUrl, token, id, data) {
  return createClient(baseUrl, token).put(`/api/usuarios/${id}`, data)
}

export function deleteUsuario(baseUrl, token, id) {
  return createClient(baseUrl, token).delete(`/api/usuarios/${id}`)
}

// ─── CATEGORIAS ────────────────────────────────────────
export function getCategorias(baseUrl, token) {
  return createClient(baseUrl, token).get('/api/categorias')
}

export function getCategoria(baseUrl, token, id) {
  return createClient(baseUrl, token).get(`/api/categorias/${id}`)
}

export function createCategoria(baseUrl, token, data) {
  return createClient(baseUrl, token).post('/api/categorias', data)
}

export function updateCategoria(baseUrl, token, id, data) {
  return createClient(baseUrl, token).put(`/api/categorias/${id}`, data)
}

export function deleteCategoria(baseUrl, token, id) {
  return createClient(baseUrl, token).delete(`/api/categorias/${id}`)
}
