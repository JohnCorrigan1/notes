<script setup lang="ts">
import { ref } from 'vue'
import EditTextArea from './EditUtils/EditTextArea.vue';
import EditContainer from './EditUtils/EditContainer.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { body: string },
        required: true
    }
})

const emit = defineEmits(['update:modelValue'])

const paragraphBody = ref(modelValue.body)

const updateBody = (e: any) => {
    emit('update:modelValue', { body: e })
}

</script>

<template>
    <EditContainer label="" type="Post Paragraph">
        <EditTextArea v-on:update:modelValue="updateBody" label="Paragraph Body" v-model="paragraphBody" />
    </EditContainer>
</template>