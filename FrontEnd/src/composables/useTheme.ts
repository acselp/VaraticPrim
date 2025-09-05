import {ref} from "vue";

const themeStorageKey = "vp-theme";

export enum AppThemes {
    Dark = "dark",
    Light = "light",
}

export const useTheme = () => {
    const theme = ref<AppThemes>(localStorage.getItem(themeStorageKey) as AppThemes || AppThemes.Light);

    const applyClass = (theme: AppThemes) => {
        const el = document.documentElement
        el.classList.add(theme);
    }

    const removeClass = (theme: AppThemes) => {
        const el = document.documentElement
        el.classList.remove(theme)
    }

    const setThemeToLocalStorage = (theme: AppThemes) => {
        localStorage.setItem(themeStorageKey, theme);
    }

    const toggleTheme = () => {
        removeClass(theme.value)
        theme.value = theme.value === AppThemes.Dark ? AppThemes.Light : AppThemes.Dark;
        applyClass(theme.value)
        setThemeToLocalStorage(theme.value)
    }

    applyClass(theme.value)
    
    return {
        toggleTheme,
        theme
    }
}