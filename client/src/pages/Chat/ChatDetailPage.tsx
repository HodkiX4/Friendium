import { useParams } from "react-router-dom"

function ChatDetailPage() {
    const { chatId } = useParams<{ chatId: string }>();
    
    return (
        <div>ChatDetailPage</div>
    )
}

export default ChatDetailPage