<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditCode from './EditUtils/EditCode.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { language: string, code: string },
        required: true
    }
})

const emit = defineEmits(['update:modelValue']);

const language = ref(modelValue.language);
const code = ref(modelValue.code);

const updateLanguage = (e: any) => {
    emit('update:modelValue', { language: e, code: code.value })
}

const updateCode = (e: any) => {
    emit('update:modelValue', { language: language.value, code: e })
}
</script>

<template>
    <EditContainer label="Code Block" type="Code Block">
        <EditInput label="Language" v-on:update:modelValue="updateLanguage" v-model="language" />
        <EditCode label="Code" v-on:update:modelValue="updateCode" v-model="code" />
    </EditContainer>
</template>
