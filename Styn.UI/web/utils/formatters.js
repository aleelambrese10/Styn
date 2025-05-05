/**
 * Formatea una fecha en formato legible
 * @param {string|Date} date - Fecha a formatear
 * @param {string} locale - Locale para el formato (default: 'es-ES')
 * @returns {string} Fecha formateada
 */
export const formatDate = (date, locale = "es-ES") => {
  if (!date) return ""

  const options = {
    year: "numeric",
    month: "long",
    day: "numeric",
  }

  return new Date(date).toLocaleDateString(locale, options)
}

/**
 * Formatea un número como moneda
 * @param {number} amount - Cantidad a formatear
 * @param {string} currency - Código de moneda (default: 'EUR')
 * @param {string} locale - Locale para el formato (default: 'es-ES')
 * @returns {string} Cantidad formateada como moneda
 */
export const formatCurrency = (amount, currency = "EUR", locale = "es-ES") => {
  if (amount === null || amount === undefined) return ""

  return new Intl.NumberFormat(locale, {
    style: "currency",
    currency: currency,
  }).format(amount)
}

/**
 * Trunca un texto a una longitud máxima
 * @param {string} text - Texto a truncar
 * @param {number} maxLength - Longitud máxima (default: 100)
 * @returns {string} Texto truncado
 */
export const truncateText = (text, maxLength = 100) => {
  if (!text) return ""

  if (text.length <= maxLength) return text

  return text.substring(0, maxLength) + "..."
}
